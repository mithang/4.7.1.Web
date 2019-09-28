import { action,observable } from 'mobx';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { GetAllProductOutput } from '../services/product/dto/getAllProductOutput';
import productService from '../services/product/productService';
import { GetProductAsyncInput } from '../services/product/dto/getProductsAsyncInput';
import { PagedProductResultRequestDto } from '../services/product/dto/PagedProductResultRequestDto';
import { EntityDto } from '../services/dto/entityDto';
import {CreateOrUpdateProductInput} from '../services/product/dto/createOrUpdateProductInput';

class ProductStore {
  @observable products!: PagedResultDto<GetAllProductOutput>;
  @observable productEdit!: CreateOrUpdateProductInput;

  @action
  async create() {
    console.log("OK");
  }
  @action
  async getProductsAsync(getProductAsyncInput: GetProductAsyncInput) {
    await productService.getProductsAsync(getProductAsyncInput);
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedProductResultRequestDto) {
    let result = await productService.getAll(pagedFilterAndSortedRequest);
    this.products = result;
  }

  @action
  async delete(entityDto: EntityDto) {
    await productService.delete(entityDto);
    this.products.items = this.products.items.filter((x: GetAllProductOutput) => x.id !== entityDto.id);
  }

  @action
  async getProduct(entityDto: EntityDto) {
    let result = await productService.getProduct(entityDto);
    this.productEdit = result;
    
  }



}

export default ProductStore;
