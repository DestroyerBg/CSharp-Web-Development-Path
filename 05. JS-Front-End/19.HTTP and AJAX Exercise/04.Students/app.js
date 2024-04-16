function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/collections/students';

    const [firstNameInput, lastNameInput, facultyNumberInput, gradeInput] = document.querySelectorAll('input[type = text');
    
    const submitButton = document.getElementById('submit');
    const reloadButton = document.getElementById('reload');
    const table = document.querySelector('#results tbody');
    submitButton.addEventListener('click', () => {
        const student = {
            firstName: firstNameInput.value,
            lastName: lastNameInput.value,
            facultyNumber: facultyNumberInput.value,
            grade: gradeInput.value, 
            
        }

        fetch(url, {
            method: 'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(student),
        })
        .then(res => res.json())
        .then(data => {

            loadStudents() 
        })
    })

    reloadButton.addEventListener('click', () =>{
        loadStudents();
    })

    async function loadStudents() {
        table.innerHTML = '';
        const getStudentsResponse = await fetch(url);
        const getStudentData = await getStudentsResponse.json();
        for (const student of Object.values(getStudentData)) {
            // first name
            const tdFirstName = document.createElement('td');
            tdFirstName.textContent = student.firstName;

            // last name
            const tdLastName = document.createElement('td');
            tdLastName.textContent = student.lastName;

            // faculty number
            const tdFacultyNumber = document.createElement('td');
            tdFacultyNumber.textContent = Number(student.facultyNumber);

             // grade
             const tdGrade = document.createElement('td');
             tdGrade.textContent = Number(student.grade);

             // create whole table row
            const studentData = document.createElement('tr');
            studentData.appendChild(tdFirstName);
            studentData.appendChild(tdLastName);
            studentData.appendChild(tdFacultyNumber);
            studentData.appendChild(tdGrade);

            table.appendChild(studentData);

            firstNameInput.value = '';
            lastNameInput.value = '';
            facultyNumberInput.value = '';
            gradeInput.value = '';
        }
    }
}

attachEvents();