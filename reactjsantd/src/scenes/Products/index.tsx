import React from "react";
import { FormComponentProps } from 'antd/lib/form';
import AppComponentBase from '../../components/AppComponentBase';
import { EntityDto } from '../../services/dto/entityDto';
import ProductStore from '../../stores/productStore';
import { inject, observer } from 'mobx-react';
import Stores from '../../stores/storeIdentifier';
import { Button, Card, Col, Dropdown, Input, Menu, Modal, Row, Table } from 'antd';
// import CreateOrUpdateRole from './components/createOrUpdateRole';
import { L } from '../../lib/abpUtility';
import FormItem from 'antd/lib/form/FormItem';
import _ from "lodash";
import * as Yup from 'yup';
import { InjectedFormikProps, withFormik } from 'formik';

// declare var abp: any;


export interface IProductProps extends FormComponentProps {
    productStore: ProductStore;
}

export interface IProductState {
    modalVisible: boolean;
    maxResultCount: number;
    skipCount: number;
    roleId: number;
    filter: string;
    name: string;
    displayName: string;

}

const confirm = Modal.confirm;
const Search = Input.Search;


//AppComponentBase trong class nay co chua ham isGranted, Không cần dùng {abp.auth.isGranted('Pages.Roles') && "Co quyen dung roles"}
@inject(Stores.ProductStore)
@observer
class Product extends AppComponentBase<InjectedFormikProps<IProductProps, IProductState>> {
    formRef: any;
    state = {
        modalVisible: false,
        maxResultCount: 10,
        skipCount: 0,
        roleId: 0,
        filter: '',
        name: "",
        displayName: ""
    };

    async componentDidMount() {
        
        await this.getAll();
       
    }

    async getAll() {
        await this.props.productStore.getAll({ maxResultCount: this.state.maxResultCount, skipCount: this.state.skipCount, keyword: this.state.filter });
    }

    Modal = () => {
        this.setState({
            modalVisible: !this.state.modalVisible,
        });
    };

    async createOrUpdateModalOpen(entityDto: EntityDto) {
    
        this.props.resetForm();
        if (entityDto.id === 0) {
          //this.props.productStore.createRole();
          //await this.props.productStore.getAllPermissions();
        } else {
            //Chạy hàm để lấy dữ liệu từ api, sau đó set vào this.props.productStore.productEdit
            await this.props.productStore.getProduct(entityDto);
          
            this.props.setFieldValue("name", this.props.productStore.productEdit.name);  
        }
        
        this.Modal();
    }

    delete(input: EntityDto) {
        const self = this;
        confirm({
            title: 'Do you Want to delete these items?',
            onOk() {
                self.props.productStore.delete(input);
            },
            onCancel() { },
        });
    }

    handleSearch = (value: string) => {
        this.setState({ filter: value }, async () => await this.getAll());
    };

    handleCreate = () => {

        const form = this.formRef.props.form;
        
        form.validateFields(async (err: any, values: any) => {
            if (err) {
                return;
            } else {
                if (this.state.roleId === 0) {
                    //await this.props.productStore.create(values);
                } else {
                    //await this.props.productStore.update({ id: this.state.roleId, ...values });
                }
            }

            await this.getAll();
            this.setState({ modalVisible: false });
            form.resetFields();
        });
    };

    render() {

        const { products } = this.props.productStore;
        const columns = [
            { title: L('RoleName'), dataIndex: 'name', key: 'name', width: 150, render: (text: string) => <div>{text}</div> },
            { title: L('DisplayName'), dataIndex: 'displayName', key: 'displayName', width: 150, render: (text: string) => <div>{text}</div> },
            {
                title: L('Actions'),
                width: 150,
                render: (text: string, item: any) => (
                    <div>
                        <Dropdown
                            trigger={['click']}
                            overlay={
                                <Menu>
                                    <Menu.Item onClick={() => this.createOrUpdateModalOpen({ id: item.id })}>{L('Edit')}</Menu.Item>
                                    <Menu.Item onClick={() => this.delete({ id: item.id })}>{L('Delete')}</Menu.Item>
                                </Menu>
                            }
                            placement="bottomLeft"
                        >
                            <Button type="primary" icon="setting">
                                {L('Actions')}
                            </Button>

                        </Dropdown>
                    </div>
                ),
            },
        ];

        return (
            <Card>

                <Row>
                    <Col
                        xs={{ span: 4, offset: 0 }}
                        sm={{ span: 4, offset: 0 }}
                        md={{ span: 4, offset: 0 }}
                        lg={{ span: 2, offset: 0 }}
                        xl={{ span: 2, offset: 0 }}
                        xxl={{ span: 2, offset: 0 }}
                    >
                        <h2>{L('Products')}</h2>
                    </Col>
                    <Col
                        xs={{ span: 14, offset: 0 }}
                        sm={{ span: 15, offset: 0 }}
                        md={{ span: 15, offset: 0 }}
                        lg={{ span: 1, offset: 21 }}
                        xl={{ span: 1, offset: 21 }}
                        xxl={{ span: 1, offset: 21 }}
                    >
                        <Button type="primary" shape="circle" icon="plus" onClick={() => this.createOrUpdateModalOpen({ id: 0 })} />
                    </Col>
                </Row>
                <Row>
                    <Col sm={{ span: 10, offset: 0 }}>
                        <Search placeholder={this.L('Filter')} onSearch={this.handleSearch} />
                    </Col>
                </Row>
                <Row style={{ marginTop: 20 }}>
                    <Col
                        xs={{ span: 24, offset: 0 }}
                        sm={{ span: 24, offset: 0 }}
                        md={{ span: 24, offset: 0 }}
                        lg={{ span: 24, offset: 0 }}
                        xl={{ span: 24, offset: 0 }}
                        xxl={{ span: 24, offset: 0 }}
                    >
                        <Table
                            rowKey="id"
                            size={'default'}
                            bordered={true}
                            pagination={{ pageSize: this.state.maxResultCount, total: products === undefined ? 0 : products.totalCount, defaultCurrent: 1 }}
                            columns={columns}
                            loading={products === undefined ? true : false}
                            dataSource={products === undefined ? [] : products.items}
                        //   onChange={this.handleTableChange}
                        />
                    </Col>
                </Row>

                <Modal
                    visible={this.state.modalVisible}
                    cancelText={L('Cancel')}
                    okText={L('OK')}
                    onCancel={() =>
                        this.Modal()
                    }
                    title={L('Products')}
                    onOk={this.props.handleSubmit}
                    // disabled={this.props.isSubmitting}
                >

                    <form onSubmit={
                        this.props.handleSubmit
                        // this.handleCreate
                        }>

                        <FormItem label={L('name')} >
                            <Input id="name"
                                placeholder="Tên sản phẩm..."
                                type="text"
                                onChange={this.props.handleChange}
                                value={this.props.values.name}
                                onBlur={this.props.handleBlur('name')} />
                            {this.props.touched.name && this.props.errors.name &&
                                <div>{this.props.errors.name}</div>}
                        </FormItem>
                        <FormItem label={L('displayName')}>
                            <Input id="displayName"
                                placeholder="Mô tả sản phẩm..."
                                type="text"
                                onChange={this.props.handleChange}
                                value={this.props.values.displayName}
                                onBlur={this.props.handleBlur('displayName')} />
                            {this.props.touched.displayName && this.props.errors.displayName &&
                                <div>{this.props.errors.displayName}</div>}
                        </FormItem>


                    </form>
                </Modal>
            </Card>
        );

    }
}
export default withFormik<IProductProps,IProductState>(
    {
        mapPropsToValues: (props) => {
            console.log(props);
            return ({
            modalVisible: false,
            maxResultCount: 10,
            skipCount: 0,
            roleId: 0,
            filter: "",
            name: "",
            displayName: ""
        })},
        mapPropsToStatus: (states) => {
            console.log(states);
            return ({
            modalVisible: false,
            maxResultCount: 10,
            skipCount: 0,
            roleId: 0,
            filter: "",
            name: "",
            displayName: ""
        })},
        // enableReinitialize: true,
        validationSchema: Yup.object().shape({
            name: Yup.string()
                .max(16, 'Please input 16 characters or less')
                .required('Tên sản phẩm không để trống'),
            displayName: Yup.string()
                .max(16, 'Please input 16 characters or less')
                .required('Mô tả không để trống'),
        },
        ),
        handleSubmit: (values, { setSubmitting }) => {
            
            setTimeout(
                () => {
                    alert(JSON.stringify(values, null, 2));
                    setSubmitting(false);
                },
                1000,
            );
        },
    }
)(Product);

// const UserSearchForm = withFormik<IProductProps, IProductState>()(Product);

// export default UserSearchForm;

