"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const forms_1 = require("@angular/forms");
const platform_browser_1 = require("@angular/platform-browser");
const http_1 = require("@angular/http");
const router_1 = require("@angular/router");
const material_1 = require("@angular/material");
const animations_1 = require("@angular/platform-browser/animations");
const app_config_1 = require("./app.config");
const app_component_1 = require("./app.component");
const exercise_search_component_1 = require("./exercise/exercise.search.component");
const exercise_view_component_1 = require("./exercise/exercise.view.component");
const dashboard_component_1 = require("./dashboard/dashboard.component");
const exercise_service_1 = require("./exercise/exercise.service");
const app_routing_module_1 = require("./app-routing.module");
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule, http_1.HttpModule, forms_1.FormsModule, router_1.RouterModule, app_routing_module_1.AppRoutingModule, animations_1.BrowserAnimationsModule, material_1.MdSidenavModule],
        declarations: [app_component_1.AppComponent, exercise_search_component_1.ExerciseSearchComponent, exercise_view_component_1.ExerciseViewComponent, dashboard_component_1.DashboardComponent],
        bootstrap: [app_component_1.AppComponent],
        providers: [{ provide: app_config_1.APP_CONFIG, useValue: app_config_1.AppConfig }, exercise_service_1.ExerciseService]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map