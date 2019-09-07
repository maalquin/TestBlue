import { Directive } from "@angular/core";
import { Validator, AbstractControl, NG_VALIDATORS } from '@angular/forms';

@Directive({
selector:'[appSelectedValidator]',
providers:[{
    provide:NG_VALIDATORS,
    useExisting:SelecRequiredValidatorDirective,
    multi:true
}]
})

export class SelecRequiredValidatorDirective implements Validator {
    validate(control: AbstractControl):{ [key:string] : any } | null {
        return control.value === '-1'? {'defaultSelected':true}:null;
    }
}