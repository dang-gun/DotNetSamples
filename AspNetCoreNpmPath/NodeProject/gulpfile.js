//https://github.com/madskristensen/NpmTaskRunner/issues/37

var path = require('path');
var gulp = require('gulp');

var basePath = path.resolve(__dirname, "wwwroot");

gulp.task('testTask', function (done)
{
    console.log('Hello World! We finished a task!');
    console.log("__filename : " + __filename);
    console.log("__dirname : " + __dirname);

    console.log("basePath : " + basePath);
    done();
});

/*
var path = require('path');
var gulp = require('gulp');

var basePath = path.resolve(__dirname, "wwwroot");

gulp.task('testTask', function (done)
{
    console.log('Hello World! We finished a task!');
    console.log("__filename : " + __filename);
    console.log("__dirname : " + __dirname);

    console.log("basePath : " + basePath);
    done();
});*/