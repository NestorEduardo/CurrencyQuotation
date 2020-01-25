import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Quotation } from "./quotation.model";

@Injectable()
export class QuotationService{
    constructor(private httpClient: HttpClient) {
    }

    public get(target: string) {
        var x = this.httpClient.get<Quotation>(`Quotation/${target}`);
        return x;
    }
}
