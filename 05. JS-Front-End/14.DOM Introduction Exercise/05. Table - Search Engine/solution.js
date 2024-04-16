function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   
   function onClick() {
      const table = document.querySelectorAll('table.container tbody tr td');
      const search = document.getElementById('searchField');

      for (const entry of Array.from(table)) {
         if (!entry.textContent.toLowerCase().includes(search.value.toLowerCase())) {
            entry.parentNode.classList.remove('select');
         }
      }
      
      for (const entry of Array.from(table)) {
         if (entry.textContent.toLowerCase().includes(search.value.toLowerCase())) {
            entry.parentNode.classList.add('select');
         }
      }

      search.value = '';
   }
}