module.exports = {
    content: ['./**/*.razor', './wwwroot/**/*.html'],
    theme: {
        extend: {
            animation: {
                'fade-in': 'fadeIn 1s ease-out forwards',
            },
        },
    },
    plugins: [],
}