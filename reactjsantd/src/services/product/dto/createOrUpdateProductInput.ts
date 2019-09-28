export interface CreateOrUpdateProductInput {
  userName: string;
  name: string;
  surname: string;
  emailAddress: string;
  isActive: boolean;
  roleNames: string[];
  password: string;
  id: number;
}
