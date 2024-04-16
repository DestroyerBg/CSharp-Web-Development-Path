function solve() {
    const[inputTextArea, resultTextArea] = document.getElementsByTagName('textarea');
    const [generateButton, buyButton] = document.getElementsByTagName('button');
    const tableBody = document.querySelector('table.table tbody');
    
    generateButton.addEventListener('click', (e) => {
        const furnitureArray = JSON.parse(inputTextArea.value);
        for (const furniture of furnitureArray) {

        // create img table data
        const imgTdElement = document.createElement('td');
        const img = document.createElement('img');
        img.src = furniture['img'];
        imgTdElement.appendChild(img);
        
        // create furniture element data
        const furnitureTdElement = document.createElement('td');
        const paragraph = document.createElement('p');
        paragraph.textContent = furniture['name'];
        furnitureTdElement.appendChild(paragraph);

        //create furnite price data 
        const furniturePriceTdElement = document.createElement('td');
        const price = document.createElement('p');
        price.textContent = furniture['price'];
        furniturePriceTdElement.appendChild(price);

        //create decoration factor data 
        const furnitureDecorationFactorTdElement = document.createElement('td');
        const decorationFactor = document.createElement('p');
        decorationFactor.textContent = furniture['decFactor'];
        furnitureDecorationFactorTdElement.appendChild(decorationFactor);

        // create checkbox 
        const checkboxTdElement = document.createElement('td');
        const input = document.createElement('input');
        input.type = 'checkbox';
        checkboxTdElement.appendChild(input);

        // create whole table row and append all data 

        const tr = document.createElement('tr');
        tr.appendChild(imgTdElement);
        tr.appendChild(furnitureTdElement);
        tr.appendChild(furniturePriceTdElement);
        tr.appendChild(furnitureDecorationFactorTdElement);
        tr.appendChild(checkboxTdElement);

        // append to tBody 
        tableBody.appendChild(tr);
    }
    })

        const boughtFurniture = [];
        const allPrices = [];
        const decFactors = [];

    buyButton.addEventListener('click', (e) => {
        const allFurnitures = Array.from(document.querySelectorAll('tbody tr'));
        
        for (const furniture of allFurnitures) {
            const input = furniture.querySelector('input');
            if (input.checked) {
                const name = furniture.querySelector('td:nth-child(2) p').textContent;
                const price = Number(furniture.querySelector('td:nth-child(3) p').textContent);
                const decFactor = Number(furniture.querySelector('td:nth-child(4) p').textContent);
                boughtFurniture.push(name);
                allPrices.push(price);
                decFactors.push(decFactor);
            }
        }

        const totalPrice = allPrices.reduce((acc,curr) => acc + curr,0);
        const averageDecFactor = decFactors.reduce((acc,curr) => acc + curr, 0 )/decFactors.length;

        const result = `Bought furniture: ${boughtFurniture.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${averageDecFactor}`;

        resultTextArea.value = result;

    })

    

}


