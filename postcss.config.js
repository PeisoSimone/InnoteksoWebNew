// postcss.config.js
module.exports = {
    plugins: [
        require('tailwindcss'),
        require('autoprefixer'),
        require('@fullhuman/postcss-purgecss')({
            content: [
                './**/*.html',
                './**/*.razor',
                './**/*.cshtml',
            ],
            defaultExtractor: content => content.match(/[\w-/:]+(?<!:)/g) || [],
            safelist: ['active', 'show', 'collapse', 'collapsing']
        })
    ]
}