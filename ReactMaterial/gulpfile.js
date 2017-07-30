var gulp = require("gulp");
var connect = require("gulp-connect");
var open = require("gulp-open");
var webpack = require('webpack-stream');
var sass = require('gulp-sass');

var config = {
    port: 9005,
    devBaseUrl: "http:localhost",
    path: {
        html: "./src/*.html",
        tsx: "./src/**/*.tsx",
        scss: "./src/style/**/*.scss",
        dist: "./dist",
        libs: "./src/libs/"
    }
};

gulp.task("watch", function () {
    gulp.watch(config.path.html, ["html"])
    gulp.watch(config.path.tsx, ["tsx"])
    gulp.watch(config.path.scss, ["scss"])
});

gulp.task("default", ["html", "tsx", "scss", "open", "watch"])

gulp.task("connect", function () {
    connect.server({url: config.devBaseUrl, port: config.port, root: ['dist'], livereload: true})
});

gulp.task("open", ["connect"], function () {
    gulp
        .src("dist/index.html")
        .pipe(open({
            uri: config.devBaseUrl + ":" + config.port + "/"
        }))
});

gulp.task("html", function () {
    gulp
        .src(config.path.html)
        .pipe(gulp.dest(config.path.dist))
        .pipe(connect.reload());
});

gulp.task('scss', function () {
    return gulp
        .src(["src/style/style.scss"])
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(config.path.dist))
        .pipe(connect.reload());
});

gulp.task('tsx', function () {
    return gulp
        .src('src/index.tsx')
        .pipe(webpack({
            watch: false,
            output: {
                filename: "app.js"
            },
            resolve: {
                extensions: ["", '.ts', '.tsx', '.js']
            },
            module: {
                loaders: [
                    {
                        test: /\.ts(x?)$/,
                        loader: 'ts-loader'
                    }
                ]
            }
        }))
        .pipe(gulp.dest("dist/"))
        .pipe(connect.reload());
});
