using System.Globalization;
using FlexiParser;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;

namespace Medicines.DataProcessor
{
    using Medicines.Data;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime searchingDate =
                DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            List<ExportPatientsDTO> patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate >= searchingDate))
                .Select(p => new ExportPatientsDTO()
                {
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    Medicines = p.PatientsMedicines.Where(pm => pm.Medicine.ProductionDate >= searchingDate)
                        .OrderByDescending(m => m.Medicine.ExpiryDate)
                        .ThenBy(m => m.Medicine.Price)
                        .Select(m => new ExportMedicineDTO()
                    {
                        Category = m.Medicine.Category.ToString().ToLower(),
                        Name = m.Medicine.Name,
                        Price = m.Medicine.Price.ToString("F2"),
                        Producer = m.Medicine.Producer,
                        BestBefore = m.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                    }).ToArray()
                }).OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToList();

            return XmlParser.SerializeToXml(patients, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop == true)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        Name = p.Pharmacy.Name,
                        PhoneNumber= p.Pharmacy.PhoneNumber,
                    },
                });

            return JsonParser.GetJson(medicines, false);
        }
    }
}
