import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { QuotationService } from '../commond/quotation.service';
import { map } from 'rxjs/operators';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Quotation } from '../commond/quotation.model';
import { debug } from 'util';


@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    quotation: Quotation;

    constructor(private quotationService: QuotationService, private route: ActivatedRoute) {
    }

    ngOnInit() {
        //debugger;
        //this.route.paramMap.pipe(
        //    map(() =>
        //        this.quotationService.get("USD"))
        //).subscribe(quotation => this.quotation = quotation);
    }
}


