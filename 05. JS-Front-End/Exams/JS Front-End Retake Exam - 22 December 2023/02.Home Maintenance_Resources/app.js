window.addEventListener("load", solve);


function solve() {
    const placeInput = document.getElementById('place');
    const actionInput = document.getElementById('action');
    const personInput = document.getElementById('person');
    const addButton = document.getElementById('add-btn');
    const taskList = document.getElementById('task-list');
    const doneTasks = document.getElementById('done-list');


    addButton.addEventListener('click',() =>{
        if (placeInput.value == '' || actionInput.value == '' || personInput.value == '') {
            return;
        }

        const element = createElement(placeInput.value, actionInput.value, personInput.value);
        taskList.appendChild(element);
        placeInput.value = ''; 
        actionInput.value = ''; 
        personInput.value = '';
    })

    function createElement(place, action, person) {
        const template = `<ul id="task-list">
        <li class="clean-task">
          <article>
            <p>Place:${place}</p>
            <p>Action:${action}</p>
            <p>Person:${person}</p>
          </article>
          <div class="buttons">
            <button class="edit">Edit</button>
            <button class="done">Done</button>
          </div>
        </li>
      </ul>`;

      const li = document.createElement('li');
      li.innerHTML = template;
      li.querySelector('button.edit').addEventListener('click', () => {
        const htmlParagraphs = li.querySelectorAll('article p');
        const info = [];
        Array.from(htmlParagraphs).map(p => info.push(p.textContent));
        placeInput.value = info.shift().split(':')[1];
        actionInput.value = info.shift().split(':')[1];
        personInput.value = info.shift().split(':')[1];
        li.remove();
      })

      li.querySelector('button.done').addEventListener('click',() => {
        li.querySelector('div.buttons').remove();
        const deleteButton = document.createElement('button');
        deleteButton.classList.add('delete');
        deleteButton.textContent = 'Delete';
        li.appendChild(deleteButton);
        deleteButton.addEventListener('click', () => {
            li.remove();
        })
        doneTasks.appendChild(li);

      })
      return li;
    }
}