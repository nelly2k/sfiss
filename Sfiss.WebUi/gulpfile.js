var gulp = require("gulp"),
    uglify = require("gulp-uglify");

var libs = "./wwwroot/libs/";

gulp.task("restore:materialize",
    function () {
        gulp.src(["node_modules/materialize-css/dist/**/*"])
            .pipe(gulp.dest(libs + "materialize"));
    });

gulp.task("restore:systemjs", function () {
    gulp.src([
        "node_modules/systemjs/dist/*.js"
    ]).pipe(gulp.dest(libs + "systemjs"));
});

gulp.task("restore:angular",
    function () {
        gulp.src(["node_modules/@angular/**/*.js"])
            .pipe(gulp.dest(libs + "@angular"));
    });


gulp.task("restore:jquery",
    function () {
        gulp.src(["node_modules/jquery/dist/*"])
            .pipe(gulp.dest(libs + "jquery"));
    });

gulp.task('restore:rxjs', function () {
    gulp.src([
        'node_modules/rxjs/**/*.js'
    ]).pipe(gulp.dest(libs + 'rxjs'));
});
gulp.task('restore:zone.js', function () {
    gulp.src([
        'node_modules/zone.js/dist/*.js'
    ]).pipe(gulp.dest(libs + 'zone.js'));
});
gulp.task('restore:reflect-metadata', function () {
    gulp.src([
        'node_modules/reflect-metadata/reflect.js'
    ]).pipe(gulp.dest(libs + 'reflect-metadata'));
});
gulp.task('restore:core-js', function () {
    gulp.src([
        'node_modules/core-js/client/*.js'
    ]).pipe(gulp.dest(libs + 'core-js'));
});
gulp.task("compress",
    function (cb) {
        pump([
                gulp.src("lib/*.js"),
                uglify(),
                gulp.dest("dist")
            ],
            cb
        );
    });

gulp.task("default", function () {
    // place code for your default task here
});

gulp.task("restore", [
    "restore:angular",
    "restore:jquery",
    "restore:materialize",
    "restore:rxjs",
    "restore:systemjs",
    "restore:zone.js",
    "restore:core-js",
    "restore:reflect-metadata"
])