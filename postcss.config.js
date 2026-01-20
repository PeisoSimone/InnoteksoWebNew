const purgecss = require('@fullhuman/postcss-purgecss');
const tailwindcss = require('tailwindcss');
const autoprefixer = require('autoprefixer');

module.exports = {
    plugins: [
        tailwindcss,
        autoprefixer,
        purgecss({
            content: [
                './wwwroot/**/*.html',
                './wwwroot/**/*.js',
                './**/*.razor'  // Adding Razor files to be scanned
            ],
            defaultExtractor: content => content.match(/[\w-/:]+(?<!:)/g) || []
        })
    ]
};
