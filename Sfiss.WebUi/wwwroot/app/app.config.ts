import { OpaqueToken } from "@angular/core";

export let APP_CONFIG = new OpaqueToken("app.config");

export interface IAppConfig {
    serviceUrl:string;
    exercisePort: string;
}

export const AppConfig: IAppConfig = {
    serviceUrl: "http://localhost",
    exercisePort: "8406"
};