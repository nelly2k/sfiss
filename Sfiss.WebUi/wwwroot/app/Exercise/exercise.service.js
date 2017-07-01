"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
const app_config_1 = require("../app.config");
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
const Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
let ExerciseService = class ExerciseService {
    constructor(config, http) {
        this.config = config;
        this.http = http;
        this.url = this.config.serviceUrl + ":" + this.config.exercisePort;
        this.headers = new http_1.Headers({ 'Content-Type': "application/json" });
    }
    search(request) {
        return this.http.post(this.url, JSON.stringify(request), new http_1.RequestOptions({ headers: this.headers }))
            .map((res) => res.json())
            .catch((error) => Observable_1.Observable.throw(error.json().error || "Server Error"));
    }
};
ExerciseService = __decorate([
    core_1.Injectable(),
    __param(0, core_1.Inject(app_config_1.APP_CONFIG)),
    __metadata("design:paramtypes", [Object, http_1.Http])
], ExerciseService);
exports.ExerciseService = ExerciseService;
//# sourceMappingURL=exercise.service.js.map