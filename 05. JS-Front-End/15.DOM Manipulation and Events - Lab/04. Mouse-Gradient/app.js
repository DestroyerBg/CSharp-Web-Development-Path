function attachGradientEvents() {
    const gradientBox = document.getElementById('gradient');
    const result = document.getElementById('result');

    gradientBox.addEventListener('mousemove', (e) => {
        const currentWidth = e.offsetX;
        const elementWidth = e.target.clientWidth;
        const progress = Math.floor((currentWidth / elementWidth) * 100);

        result.textContent = `${progress}%`
    });
}