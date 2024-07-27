using System.Globalization;
using System.Text;
using FlexiParser;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPatientsDTO[] patientsDtos = JsonParser.ParseJson<ImportPatientsDTO[]>(jsonString);

            foreach (ImportPatientsDTO patientDto in patientsDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    FullName = patientDto.FullName,
                    Gender = (Gender)patientDto.Gender,
                };

                foreach (int dtoMedicine in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(p => p.MedicineId == dtoMedicine))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = dtoMedicine,
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                context.Patients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName,
                    patient.PatientsMedicines.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPharmaciesDTO[] pharmaciesDtos =
                XmlParser.DeserializeXML<ImportPharmaciesDTO[]>(xmlString, "Pharmacies");
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            foreach (ImportPharmaciesDTO pharmacyDto in pharmaciesDtos)
            {
                if (!IsValid(pharmacyDto) || !bool.TryParse(pharmacyDto.NonStop.ToString(), out bool nonStop))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var pharmacy = new Pharmacy()
                {
                    IsNonStop = bool.Parse(pharmacyDto.NonStop.ToString()),
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                };
                context.Pharmacies.Add(pharmacy);

                foreach (ImportMedicinesDTO medicineDTO in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDTO)
                        || medicineDTO.ProductionDateDate >= medicineDTO.ExpiryDateDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(p => p.Name == medicineDTO.Name && p.Producer == medicineDTO.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if ((!context.Medicines.Any(p => p.Producer == medicineDTO.Producer && p.Name == medicineDTO.Name)) &&
                        pharmacy.Medicines.Any(p => p.Name == medicineDTO.Name && p.Producer == medicineDTO.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var medicine = new Medicine()
                    {
                        Name = medicineDTO.Name,
                        Category = (Category)medicineDTO.Category,
                        ExpiryDate = DateTime.ParseExact(medicineDTO.ExpiryDate, "yyyy-MM-dd",
                            CultureInfo.InvariantCulture, DateTimeStyles.None),
                        ProductionDate = DateTime.ParseExact(medicineDTO.ProductionDate, "yyyy-MM-dd",
                            CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Pharmacy = pharmacy,
                        Price = medicineDTO.Price,
                        Producer = medicineDTO.Producer,
                    };
                    context.Medicines.Add(medicine);

                }
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
