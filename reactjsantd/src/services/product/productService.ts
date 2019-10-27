// import { CreateRoleInput } from './dto/createRoleInput';
// import { CreateRoleOutput } from './dto/createRoleOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllProductOutput } from './dto/getAllProductOutput';
import { GetProductAsyncInput } from './dto/getProductsAsyncInput';
import GetProductAsyncOutput from './dto/getProductAsyncOutput';
import { CreateOrUpdateProductInput } from './dto/createOrUpdateProductInput';
import { PagedResultDto } from '../dto/pagedResultDto';
import { PagedProductResultRequestDto } from './dto/PagedProductResultRequestDto';
// import { UpdateRoleInput } from './dto/updateRoleInput';
// import { UpdateRoleOutput } from './dto/updateRoleOutput';


import http from '../httpService';

class ProductService {
  public async create(createProductInput: CreateOrUpdateProductInput) {
    let result = await http.post('api/services/app/Products/CreateProduct', createProductInput);
    return result.data.result;
  }
  public async getProductsAsync(getProductAsyncInput: GetProductAsyncInput): Promise<GetProductAsyncOutput> {
    let result = await http.get('api/services/app/Product/GetProductsAsync', { params: getProductAsyncInput });
    return result.data.result;
  }

  public async update(updateRoleInput: CreateOrUpdateProductInput): Promise<CreateOrUpdateProductInput> {
    let result = await http.put('api/services/app/Products/UpdateProduct', updateRoleInput);
    return result.data.result as CreateOrUpdateProductInput;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Products/DeleteProduct', { params: entityDto });
    return result.data;
  }

  // public async getAllPermissions() {
  //   let result = await http.get('api/services/app/Role/GetAllPermissions');
  //   return result.data.result.items;
  // }

  public async getProduct(entityDto: EntityDto): Promise<CreateOrUpdateProductInput> {
    let result = await http.get('/api/services/app/Products/GetProduct', { params: entityDto });
    return result.data.result;
  }

  // public async get(entityDto: EntityDto) {
  //   let result = await http.get('api/services/app/Role/Get', { params: entityDto });
  //   return result.data;
  // }

  public async getAll(pagedFilterAndSortedRequest: PagedProductResultRequestDto): Promise<PagedResultDto<GetAllProductOutput>> {
    let result = await http.get('api/services/app/Products/GetAllProduct', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }
}

export default new ProductService();
