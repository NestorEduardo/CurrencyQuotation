import { Component, OnInit } from '@angular/core';
import { QuotationService } from '../commond/quotation.service';
import { Quotation } from '../commond/quotation.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})

export class FetchDataComponent implements OnInit {
    quotation: Quotation;

    constructor(private quotationService: QuotationService, private route: ActivatedRoute) {
    }

    ngOnInit() {
        this.quotationService.get("USD").subscribe(data => {
            this.quotation = data;
            console.log(this.quotation);
        });
    }
}
