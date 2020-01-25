import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Quotation } from "./quotation.model";
import { debug } from "util";

@Injectable()
export class QuotationService{
    constructor(private httpClient: HttpClient) {
    }

    public get(target: string) {
        debugger;
        return this.httpClient.get<Quotation>(`Quotation/get/${target}`);
    }
}
