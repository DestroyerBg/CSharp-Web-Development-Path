function search() {
   const towns = document.getElementById('towns').children;
   const search = document.getElementById('searchText').value.toLowerCase();
   const result = document.getElementById(`result`);
   let matches = 0;
   for (const town of Array.from(towns)) {
      if (town.textContent.toLowerCase().includes(search)) {
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
         matches++;
      }else{
         town.style.textDecoration = 'none';
         town.style.fontWeight = 'normal';
      }
   }
   search.value = '';
   result.textContent = `${matches} matches found`;
   document.getElementById('searchText').value = '';
}

