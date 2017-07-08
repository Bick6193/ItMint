var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');

var destPath = './wwwroot/lib';

// Delete the dist directory
gulp.task('clean', function () {
    return gulp.src(destPath)
        .pipe(clean());
});

gulp.task("copy", function () {
    gulp.src([
        'core-js/client/*.js',
        'systemjs/dist/*.js',
        'reflect-metadata/*.js',
        'rxjs/**',
        'zone.js/dist/*.js',
        '@angular/**/bundles/*.js',
        'bootstrap/dist/js/*.js'
    ], {
            cwd: "node_modules/**"
        })
        .pipe(gulp.dest("./wwwroot/lib"));
});

gulp.task('default', ['copy']);