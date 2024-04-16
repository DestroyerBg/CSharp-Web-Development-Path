const url = 'http://localhost:3030/jsonstore/tasks';

const loadHistoryButton = document.getElementById('load-history');
const weatherList = document.getElementById('list');
const addWeatherButton = document.getElementById('add-weather');
const editWeatherButton = document.getElementById('edit-weather');
const locationInput = document.getElementById('location');
const temperatureInput = document.getElementById('temperature');
const dateInput = document.getElementById('date');

loadHistoryButton.addEventListener('click', () => {
    editWeatherButton.disabled = true;
    loadPosts();
});

addWeatherButton.addEventListener('click', () => {
    const location = locationInput.value;
    const temperature = temperatureInput.value;
    const date = dateInput.value;
    
    const newElement = {
        location,
        temperature,
        date,
    }
    
    fetch(url, {
        method: 'POST',
        headers:{
            'content-type': 'application/json',
        },
        body: JSON.stringify(newElement),
    })
    .then(res => {
        if (res.ok) {
            locationInput.value = '';
            temperatureInput.value = '';
            dateInput.value = '';
            loadPosts();
        }
    })
})



function createHtmlElement(entry) {
    const div = document.createElement('div');
    div.classList.add('container');
    
    const locationParagraph = document.createElement('h2');
    locationParagraph.textContent = entry.location;
    
    const dateParagraph = document.createElement('h3');
    dateParagraph.textContent = entry.date;
    
    const gradusParagraph = document.createElement('h3');
    gradusParagraph.id = 'celsius';
    gradusParagraph.textContent = entry.temperature;
    
    div.appendChild(locationParagraph);
    div.appendChild(dateParagraph);
    div.appendChild(gradusParagraph);
    
    const buttonsContainerDiv = document.createElement('div');
    buttonsContainerDiv.classList.add('buttons-container');
    
    const changeButton = document.createElement('button');
    changeButton.classList.add('change-btn');
    changeButton.textContent = 'Change';
    
    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn');
    deleteButton.textContent = 'Delete';
    
    buttonsContainerDiv.appendChild(changeButton);
    buttonsContainerDiv.appendChild(deleteButton);
    
    div.appendChild(buttonsContainerDiv);
    
    changeButton.addEventListener('click', () => {
        locationInput.value = entry.location;
        temperatureInput.value = entry.temperature;
        dateInput.value =  entry.date;
        div.remove();
        addWeatherButton.disabled = true;
        editWeatherButton.disabled = false;

        editWeatherButton.addEventListener('click', () => {
            const newWeather = {
                location: locationInput.value,
                temperature: temperatureInput.value,
                date: dateInput.value,
                _id: entry._id,
            };

            fetch(`${url}/${entry._id}`,{
                method: 'PUT',
                headers: {
                    'content-type': 'application/json',
                },
                body: JSON.stringify(newWeather),
            })
            .then(res => {
                if (res.ok) {
                    locationInput.value = '';
                    temperatureInput.value = '';
                    dateInput.value = '';
                    loadPosts();
                    addWeatherButton.disabled = false;
                    editWeatherButton.disabled = true;
                }
            })
            
        })
    })

    deleteButton.addEventListener('click', () => {
        fetch(`${url}/${entry._id}`,{
            method: 'DELETE'
        })
        .then(res => {
            if (res.ok) {
                loadPosts();
            }
        })
    })


    weatherList.appendChild(div);

    

}

function loadPosts() {
    weatherList.innerHTML = '';
    fetch(url)
    .then(res => res.json())
    .then(data => {
        Object.values(data)
        .forEach(entry => createHtmlElement(entry));
        console.log(data);
    });
}


