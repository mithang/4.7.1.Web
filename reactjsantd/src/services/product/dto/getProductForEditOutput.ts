export interface Product {
  name: string;
  displayName: string;
  description?: any;
  id: number;
}


export interface GetProductForEditOutput {
  role: Product;
}
