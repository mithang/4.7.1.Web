export interface GetProductAsyncOutputItem {
  name: string;
  displayName: string;
  isDefault: boolean;
  isStatic: boolean;
  creationTime: Date;
  id: number;
}

export default interface GetProductAsyncOutput {
  items: GetProductAsyncOutputItem[];
}
