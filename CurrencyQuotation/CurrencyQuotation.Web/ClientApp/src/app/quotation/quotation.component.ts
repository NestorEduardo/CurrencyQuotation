import { Component, OnInit } from '@angular/core';
import { QuotationService } from '../common/quotation.service';
import { Quotation } from '../common/quotation.model';
import { Config } from '../common/config';

@Component({
    selector: 'quotation',
    templateUrl: './quotation.component.html'
})

export class QuotationComponent implements OnInit {
    quotation: Quotation;
    private countryCodes: string[];
    private i: number = 0;

    constructor(private quotationService: QuotationService, private config: Config) {
    }

    ngOnInit() {
       this.countryCodes = this.config.getCountryCodes();
        setInterval(() => { this.get() }, 5000);
    }

    get() {
        this.quotationService.get(this.countryCodes[this.i]).subscribe(data => {
            this.quotation = data;
            if (this.i == this.countryCodes.length - 1) {
                this.i = 0;
            } else {
                this.i++;
            }
        });
    }
}
