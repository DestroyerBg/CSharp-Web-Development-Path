function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      const input = document.querySelector('#inputs textarea');
      const bestRestaurant = document.querySelector('#bestRestaurant p')
      const workers = document.querySelector('#workers p');

      const restaurants = {};
      const inputArr = JSON.parse(input.value);
      for (const restaurant of inputArr) {
         const [restaurantName, workersInfo] = restaurant.split(' - ');
         if (!restaurants.hasOwnProperty(restaurantName)) {
            restaurants[restaurantName] = [];
         }

         const workersArr = workersInfo.split(', ');

         for (const worker of workersArr) {
            const workerTokens = worker.split(' ');
            const workerName = workerTokens[0];
            const workerSalary = workerTokens[1];
            restaurants[restaurantName].push(`${workerName} - ${workerSalary}`);
         }
      }
      let getBestRestaurant;
      let currSalary = 0;
      let highestSalary = 0;

      for (const restaurant in restaurants) {
         currSalary = 0;
         restaurants[restaurant].forEach(r => {
            let salary = Number(r.split(' - ')[1]);
            currSalary+=salary;
         })
         currSalary/=restaurants[restaurant].length;
         if (currSalary > highestSalary) {
            highestSalary = currSalary;
            getBestRestaurant = restaurant;
         }
      }

      let getBestRestaurantReference = Object.entries(restaurants).find(r => r[0] == getBestRestaurant);

      getBestRestaurantReference[1].sort((a,b) => Number(b.split(' - ')[1]) - Number(a.split(' - ')[1]))

      let bestSalary = 0;
      getBestRestaurantReference[1].forEach(r => {
         const workerTokens = r.split(' - ');
         let currSalary = Number(workerTokens[1]);
         if (currSalary > bestSalary) {
            bestSalary = currSalary;
         }
      });

      
      bestRestaurant.textContent = `Name: ${getBestRestaurant} Average Salary: ${highestSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;

      let workersOutput = '';

      // getBestRestaurantReference.forEach(r => {
      //    const workerTokens = r[1].split(' - ');
      //    const workerName = workerTokens[0];
      //    const workerSalary = Number(workerTokens[1])
      //    workersOutput = workersOutput + `Name: ${workerName} With Salary: ${workerSalary.toFixed(2)}`;
      // });

      for (const worker of getBestRestaurantReference[1]) {
         const workerTokens = worker.split(' - ');
         const workerName = workerTokens[0];
         const workerSalary = Number(workerTokens[1])
         workersOutput = workersOutput + ` Name: ${workerName} With Salary: ${workerSalary.toFixed(0)}`;
      }

      workers.textContent = workersOutput;

      input.value = '';
   }
}