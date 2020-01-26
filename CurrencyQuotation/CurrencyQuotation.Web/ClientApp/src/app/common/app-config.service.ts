import { Injectable, } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Location } from '@angular/common';

@Injectable()
export class ConfigService {

    private config: any;

    constructor(private location: Location, private http: HttpClient) {
    }

    async getCountryCodes(): Promise<string> {
        let conf = await this.getConfig();
        return Promise.resolve(conf.countryCodes);
    }

    private async getConfig(): Promise<any> {
        if (!this.config) {
            this.config = (await this.http.get(this.location.prepareExternalUrl('/assets/config.json')).toPromise());
        }
        return Promise.resolve(this.config);
    }
}
