function solve() {
   //get elements
   const addButtons = document.querySelectorAll('button.add-product');
   const checkout = document.querySelector('button.checkout');
   const textArea = document.querySelector('div textarea');
   let total = 0;
   let products = [];

   // addFunction
   const eventAddFunction = (e) => {
      const product = e.target.parentElement.parentElement.querySelector('div.product-title').textContent;
      const sum = Number(e.target.parentElement.parentElement.querySelector('div.product-line-price').textContent);
      total+=sum;
      if (!products.some(s => s == product)) {
         products.push(product);
      }
      textArea.value = textArea.value + `Added ${product} for ${sum.toFixed(2)} to the cart.\n`
   };

   // checkout buttonFunction
   const eventCheckoutFunction = (e) => {
      textArea.value = textArea.value + `You bought ${products.join(', ')} for ${total.toFixed(2)}.`;
      Array.from(addButtons).forEach(b => {
         b.removeEventListener('click',eventAddFunction);
      })
      checkout.removeEventListener('click', eventCheckoutFunction);
   };
   
   // adding eventListeners
   Array.from(addButtons).forEach(b => {
      b.addEventListener('click', eventAddFunction);
   });

   // add checkout eventlisteners and after this event all buttons will be disabled
   checkout.addEventListener('click', eventCheckoutFunction);

   
}