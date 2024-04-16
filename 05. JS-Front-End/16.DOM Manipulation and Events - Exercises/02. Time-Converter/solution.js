function attachEventsListeners() {
    const convertDaysBtn = document.getElementById('daysBtn');
    const convertHoursBtn = document.getElementById('hoursBtn');
    const convertMinutesBtn = document.getElementById('minutesBtn');
    const convertSecondsBtn = document.getElementById('secondsBtn');

    const daysField = document.getElementById('days');
    const hoursField = document.getElementById('hours');
    const minutesField = document.getElementById('minutes');
    const secondsField = document.getElementById('seconds');

    convertDaysBtn.addEventListener('click', () => display(Number(daysField.value * 86400)));
    convertHoursBtn.addEventListener('click', () => display(Number(hoursField.value * 3600)));
    convertMinutesBtn.addEventListener('click',() => display(Number(minutesField.value * 60)));
    convertSecondsBtn.addEventListener('click', () => display(Number(secondsField.value)));

    function display(seconds) {
        secondsField.value = seconds;
        minutesField.value = Number(seconds / 60);
        hoursField.value = Number(minutesField.value / 60);
        daysField.value = Number(hoursField.value / 24);
    }
    
}