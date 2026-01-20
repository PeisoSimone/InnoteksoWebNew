// ============================================
// TECH-ENHANCED JAVASCRIPT
// ============================================

// Scroll to Top Button
document.addEventListener('DOMContentLoaded', () => {
    const scrollToTopBtn = document.getElementById('scrollToTop');

    if (scrollToTopBtn) {
        window.addEventListener('scroll', () => {
            if (window.scrollY > 300) {
                scrollToTopBtn.classList.add('visible');
            } else {
                scrollToTopBtn.classList.remove('visible');
            }
        });

        scrollToTopBtn.addEventListener('click', () => {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });
    }
});

// Navbar Scroll Effect
window.addEventListener('scroll', () => {
    const navbar = document.getElementById('mainNav');
    if (navbar) {
        if (window.scrollY > 50) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }
    }
});

// Initialize scroll animations
export function initScrollAnimations() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
                // Trigger counter animation when stats section is visible
                if (entry.target.classList.contains('stat-item')) {
                    animateCounter(entry.target);
                }
            }
        });
    }, observerOptions);

    const animatedElements = document.querySelectorAll('.animate-on-scroll');
    animatedElements.forEach(el => observer.observe(el));
}

// Counter Animation
function animateCounter(element) {
    const numberElement = element.querySelector('.stat-number');
    if (!numberElement || numberElement.classList.contains('counted')) return;

    const target = parseInt(numberElement.getAttribute('data-target'));
    const duration = 2000;
    const step = target / (duration / 16);
    let current = 0;

    const timer = setInterval(() => {
        current += step;
        if (current >= target) {
            numberElement.textContent = target;
            numberElement.classList.add('counted');
            clearInterval(timer);
        } else {
            numberElement.textContent = Math.floor(current);
        }
    }, 16);
}

// Smooth scroll to element
window.scrollToElement = function (elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        const offset = 80;
        const elementPosition = element.getBoundingClientRect().top;
        const offsetPosition = elementPosition + window.pageYOffset - offset;

        window.scrollTo({
            top: offsetPosition,
            behavior: 'smooth'
        });
    }
};

// Particle Effect Generator
class ParticleEffect {
    constructor(container) {
        this.container = container;
        this.particles = [];
        this.particleCount = 50;
        this.init();
    }

    init() {
        for (let i = 0; i < this.particleCount; i++) {
            this.createParticle();
        }
        this.animate();
    }

    createParticle() {
        const particle = document.createElement('div');
        particle.className = 'tech-particle';
        particle.style.cssText = `
            position: absolute;
            width: ${Math.random() * 4 + 1}px;
            height: ${Math.random() * 4 + 1}px;
            background: rgba(0, 102, 255, ${Math.random() * 0.5 + 0.2});
            border-radius: 50%;
            pointer-events: none;
            left: ${Math.random() * 100}%;
            top: ${Math.random() * 100}%;
            animation: float ${Math.random() * 10 + 10}s infinite ease-in-out;
            animation-delay: ${Math.random() * 5}s;
        `;

        this.container.appendChild(particle);
        this.particles.push(particle);
    }

    animate() {
        requestAnimationFrame(() => this.animate());
    }
}

// Initialize particles on page load
document.addEventListener('DOMContentLoaded', () => {
    const particleContainers = document.querySelectorAll('.nav-particles, .footer-particles');
    particleContainers.forEach(container => {
        if (container) {
            new ParticleEffect(container);
        }
    });
});

// Mouse Trail Effect
let mouseX = 0;
let mouseY = 0;
let trailElements = [];

document.addEventListener('mousemove', (e) => {
    mouseX = e.clientX;
    mouseY = e.clientY;

    // Create trail effect on specific sections
    if (e.target.closest('.hero-section-clean, .cta-section-clean')) {
        createTrailDot(mouseX, mouseY);
    }
});

function createTrailDot(x, y) {
    const dot = document.createElement('div');
    dot.className = 'mouse-trail-dot';
    dot.style.cssText = `
        position: fixed;
        width: 8px;
        height: 8px;
        background: radial-gradient(circle, rgba(0, 217, 255, 0.8), transparent);
        border-radius: 50%;
        pointer-events: none;
        z-index: 9999;
        left: ${x}px;
        top: ${y}px;
        transform: translate(-50%, -50%);
        animation: fadeOut 0.8s forwards;
    `;

    document.body.appendChild(dot);

    setTimeout(() => {
        dot.remove();
    }, 800);
}

// Add fadeOut animation dynamically
if (!document.getElementById('trail-animation')) {
    const style = document.createElement('style');
    style.id = 'trail-animation';
    style.textContent = `
        @keyframes fadeOut {
            0% { opacity: 1; transform: translate(-50%, -50%) scale(1); }
            100% { opacity: 0; transform: translate(-50%, -50%) scale(0); }
        }
    `;
    document.head.appendChild(style);
}

// Typing Effect for Headlines
class TypingEffect {
    constructor(element, text, speed = 100) {
        this.element = element;
        this.text = text;
        this.speed = speed;
        this.index = 0;
        this.type();
    }

    type() {
        if (this.index < this.text.length) {
            this.element.textContent += this.text.charAt(this.index);
            this.index++;
            setTimeout(() => this.type(), this.speed);
        }
    }
}

// Glitch Effect
function addGlitchEffect(element) {
    element.addEventListener('mouseenter', () => {
        element.classList.add('glitch-active');
        setTimeout(() => {
            element.classList.remove('glitch-active');
        }, 500);
    });
}

// Apply glitch effect to specific elements
document.addEventListener('DOMContentLoaded', () => {
    const glitchElements = document.querySelectorAll('.service-title-clean, .package-name-clean');
    glitchElements.forEach(el => {
        if (el) addGlitchEffect(el);
    });
});

// Card Tilt Effect
class CardTilt {
    constructor(card) {
        this.card = card;
        this.init();
    }

    init() {
        this.card.addEventListener('mousemove', (e) => this.handleMove(e));
        this.card.addEventListener('mouseleave', () => this.handleLeave());
    }

    handleMove(e) {
        const rect = this.card.getBoundingClientRect();
        const x = e.clientX - rect.left;
        const y = e.clientY - rect.top;

        const centerX = rect.width / 2;
        const centerY = rect.height / 2;

        const rotateX = (y - centerY) / 10;
        const rotateY = (centerX - x) / 10;

        this.card.style.transform = `perspective(1000px) rotateX(${rotateX}deg) rotateY(${rotateY}deg) scale3d(1.02, 1.02, 1.02)`;
    }

    handleLeave() {
        this.card.style.transform = 'perspective(1000px) rotateX(0) rotateY(0) scale3d(1, 1, 1)';
    }
}

// Apply tilt effect to cards
document.addEventListener('DOMContentLoaded', () => {
    const cards = document.querySelectorAll('.service-card-clean, .pricing-card-clean, .why-card');
    cards.forEach(card => {
        if (card) {
            card.style.transition = 'transform 0.1s ease';
            new CardTilt(card);
        }
    });
});

// Parallax Effect
window.addEventListener('scroll', () => {
    const scrolled = window.pageYOffset;
    const parallaxElements = document.querySelectorAll('.hero-section-clean::before');

    parallaxElements.forEach(element => {
        const speed = 0.5;
        element.style.transform = `translateY(${scrolled * speed}px)`;
    });
});

// Binary Rain Effect (Matrix style)
class BinaryRain {
    constructor(canvas) {
        this.canvas = canvas;
        this.ctx = canvas.getContext('2d');
        this.fontSize = 14;
        this.columns = canvas.width / this.fontSize;
        this.drops = [];

        for (let i = 0; i < this.columns; i++) {
            this.drops[i] = 1;
        }

        this.init();
    }

    init() {
        setInterval(() => this.draw(), 50);
    }

    draw() {
        this.ctx.fillStyle = 'rgba(10, 17, 40, 0.05)';
        this.ctx.fillRect(0, 0, this.canvas.width, this.canvas.height);

        this.ctx.fillStyle = 'rgba(0, 102, 255, 0.8)';
        this.ctx.font = `${this.fontSize}px monospace`;

        for (let i = 0; i < this.drops.length; i++) {
            const text = Math.random() > 0.5 ? '1' : '0';
            this.ctx.fillText(text, i * this.fontSize, this.drops[i] * this.fontSize);

            if (this.drops[i] * this.fontSize > this.canvas.height && Math.random() > 0.975) {
                this.drops[i] = 0;
            }
            this.drops[i]++;
        }
    }
}

// Newsletter Form Handler
document.addEventListener('DOMContentLoaded', () => {
    const newsletterForm = document.querySelector('.newsletter-form');
    const newsletterButton = document.querySelector('.newsletter-button');
    const newsletterInput = document.querySelector('.newsletter-input');

    if (newsletterButton && newsletterInput) {
        newsletterButton.addEventListener('click', (e) => {
            e.preventDefault();
            const email = newsletterInput.value;

            if (email && validateEmail(email)) {
                // Show success animation
                newsletterButton.innerHTML = '<i class="fas fa-check"></i>';
                newsletterButton.style.background = '#00E676';

                setTimeout(() => {
                    newsletterButton.innerHTML = '<i class="fas fa-arrow-right"></i>';
                    newsletterButton.style.background = '';
                    newsletterInput.value = '';
                }, 2000);
            } else {
                // Show error animation
                newsletterInput.style.borderColor = '#FF6B6B';
                setTimeout(() => {
                    newsletterInput.style.borderColor = '';
                }, 1000);
            }
        });
    }
});

// Email Validation
function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}

// Loading Animation
window.addEventListener('load', () => {
    document.body.classList.add('loaded');

    // Trigger entrance animations
    const heroElements = document.querySelectorAll('.fade-in, .fade-in-delay, .fade-in-delay-2');
    heroElements.forEach((el, index) => {
        setTimeout(() => {
            el.style.opacity = '1';
            el.style.transform = 'translateY(0)';
        }, index * 200);
    });
});

// Active Section Tracking
function updateActiveSection() {
    const sections = document.querySelectorAll('section[id]');
    const navLinks = document.querySelectorAll('.nav-link-tech');

    let currentSection = '';

    sections.forEach(section => {
        const sectionTop = section.offsetTop;
        const sectionHeight = section.clientHeight;
        if (window.scrollY >= (sectionTop - 100)) {
            currentSection = section.getAttribute('id');
        }
    });

    navLinks.forEach(link => {
        link.classList.remove('active');
        if (link.getAttribute('href') === `#${currentSection}`) {
            link.classList.add('active');
        }
    });
}

window.addEventListener('scroll', updateActiveSection);

// Make functions globally available for Blazor
window.siteEffects = {
    initScrollAnimations,
    validateEmail
};

// ============================================
// MOBILE NAVIGATION FUNCTIONALITY
// ============================================

// Mobile menu toggle handler
document.addEventListener('DOMContentLoaded', function () {
    const toggler = document.querySelector('.navbar-toggler-tech');
    const menu = document.querySelector('.navbar-menu-tech');
    const body = document.body;

    // Create backdrop element
    const backdrop = document.createElement('div');
    backdrop.className = 'mobile-menu-backdrop';
    document.body.appendChild(backdrop);

    if (toggler && menu) {
        // Toggle menu on button click
        toggler.addEventListener('click', function () {
            const isActive = menu.classList.contains('active');

            if (isActive) {
                // Close menu
                menu.classList.remove('active');
                toggler.classList.remove('active');
                backdrop.classList.remove('active');
                body.classList.remove('menu-open');
            } else {
                // Open menu
                menu.classList.add('active');
                toggler.classList.add('active');
                backdrop.classList.add('active');
                body.classList.add('menu-open');
            }
        });

        // Close menu on backdrop click
        backdrop.addEventListener('click', function () {
            menu.classList.remove('active');
            toggler.classList.remove('active');
            backdrop.classList.remove('active');
            body.classList.remove('menu-open');
        });

        // Close menu when clicking nav links
        const navLinks = document.querySelectorAll('.nav-link-tech');
        navLinks.forEach(link => {
            link.addEventListener('click', function () {
                // Only close on mobile
                if (window.innerWidth <= 968) {
                    menu.classList.remove('active');
                    toggler.classList.remove('active');
                    backdrop.classList.remove('active');
                    body.classList.remove('menu-open');
                }
            });
        });

        // Close menu on ESC key
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape' && menu.classList.contains('active')) {
                menu.classList.remove('active');
                toggler.classList.remove('active');
                backdrop.classList.remove('active');
                body.classList.remove('menu-open');
            }
        });

        // Handle window resize
        window.addEventListener('resize', function () {
            if (window.innerWidth > 968) {
                menu.classList.remove('active');
                toggler.classList.remove('active');
                backdrop.classList.remove('active');
                body.classList.remove('menu-open');
            }
        });
    }
});

// Prevent scroll jumping when menu opens
document.addEventListener('DOMContentLoaded', function () {
    const menu = document.querySelector('.navbar-menu-tech');

    if (menu) {
        menu.addEventListener('touchmove', function (e) {
            // Prevent scroll on body when menu is open
            if (document.body.classList.contains('menu-open')) {
                const menuContent = e.currentTarget;
                const scrollTop = menuContent.scrollTop;
                const scrollHeight = menuContent.scrollHeight;
                const height = menuContent.clientHeight;
                const delta = e.touches[0].clientY - (e.touches[1]?.clientY || e.touches[0].clientY);

                if ((delta < 0 && scrollTop === 0) ||
                    (delta > 0 && scrollTop + height === scrollHeight)) {
                    e.preventDefault();
                }
            }
        }, { passive: false });
    }
});

// Smooth scroll for mobile navigation
document.addEventListener('DOMContentLoaded', function () {
    const navLinks = document.querySelectorAll('.nav-link-tech[href^="#"]');

    navLinks.forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();

            const targetId = this.getAttribute('href').substring(1);
            const targetElement = document.getElementById(targetId);

            if (targetElement) {
                // Calculate offset for fixed nav
                const navHeight = document.querySelector('.navbar-tech')?.offsetHeight || 70;
                const targetPosition = targetElement.offsetTop - navHeight;

                // Smooth scroll
                window.scrollTo({
                    top: targetPosition,
                    behavior: 'smooth'
                });
            }
        });
    });
});