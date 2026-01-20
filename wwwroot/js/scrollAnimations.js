window.initScrollAnimations = function () {
    const observerOptions = {
        threshold: [0.9], // At least 50% of the element should be visible
        rootMargin: "0px 0px 0px 0px"
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.intersectionRatio >= 0.5) {
                // Fully or mostly visible
                entry.target.classList.add('scroll-in');
                entry.target.classList.remove('scroll-out', 'opacity-0', 'translate-y-10');
            } else {
                // Not fully visible
                entry.target.classList.add('scroll-out');
                entry.target.classList.remove('scroll-in', 'opacity-0', 'translate-y-10');
            }
        });
    }, observerOptions);

    const animatedElements = document.querySelectorAll('.animate-on-scroll');
    animatedElements.forEach(el => observer.observe(el));

    return () => {
        animatedElements.forEach(el => observer.unobserve(el));
    };
};

// Optional: Debounced scroll handler for performance optimization
let scheduledAnimation = false;
window.addEventListener('scroll', () => {
    if (!scheduledAnimation) {
        scheduledAnimation = true;
        requestAnimationFrame(() => {
            scheduledAnimation = false;
        });
    }
}, { passive: true });
