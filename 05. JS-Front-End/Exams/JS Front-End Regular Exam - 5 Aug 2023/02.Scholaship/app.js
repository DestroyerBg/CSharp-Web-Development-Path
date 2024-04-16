window.addEventListener("load", solve);

function solve() {
    const nextButton = document.getElementById('next-btn');
    const studentInput = document.getElementById('student');
    const universityInput = document.getElementById('university');
    const scoreInput = document.getElementById('score');
    const previewList = document.getElementById('preview-list');
    const candidatesList = document.getElementById('candidates-list');
    nextButton.addEventListener('click', () => {
        if (!studentInput.value || !universityInput.value || !scoreInput.value) {
            return;   
        }
        createElement(studentInput.value, universityInput.value, scoreInput.value);
        clearInputData();
        nextButton.disabled = true;
    })

    function createElement(studentName, university, score) {
        const li = document.createElement('li');
        li.classList.add('application');

        const article = document.createElement('article');

        const nameH4 = document.createElement('h4');
        nameH4.textContent = studentName;

        const universityParagraph = document.createElement('p');
        universityParagraph.textContent = `University: ${university}`;

        const scoreParagraph = document.createElement('p');
        scoreParagraph.textContent = `Score: ${score}`;

        article.appendChild(nameH4);
        article.appendChild(universityParagraph);
        article.appendChild(scoreParagraph);

        li.appendChild(article);

        const editButton = document.createElement('button');
        editButton.classList.add('action-btn');
        editButton.classList.add('edit');
        editButton.textContent = 'edit';

        const applyButton = document.createElement('button');
        applyButton.classList.add('action-btn');
        applyButton.classList.add('apply');
        applyButton.textContent = 'apply';

        li.appendChild(editButton);
        li.appendChild(applyButton);

        editButton.addEventListener('click', () => {
            li.remove();
            studentInput.value = studentName;
            universityInput.value = university;
            scoreInput.value = score;
            nextButton.disabled = false;
        })

        applyButton.addEventListener('click', () => {
            li.remove();
            li.querySelector('.edit').remove();
            li.querySelector('.apply').remove();
            candidatesList.appendChild(li);
            nextButton.disabled = false;
        })

        previewList.appendChild(li);
    }

    function clearInputData() {
        studentInput.value = '';
        universityInput.value = '';
        scoreInput.value = '';
    }
}
