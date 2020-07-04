import { IProduct } from "./Product";

export interface IInvoice {
    customerId: number;
    lineItems: ILineItem[];
    createdOn: Date;
    updatedOn: Date;
}

export interface ILineItem {
    quantity: number;
    product?: IProduct;
}

