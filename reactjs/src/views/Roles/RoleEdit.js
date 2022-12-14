import React, { Component } from 'react';
import { Card, CardBody, Badge, CardHeader, Col, Row, CardFooter, Button, FormGroup, Label, Input, FormText } from 'reactstrap';
import withAuth from '../../hoc/withAuth';
import _ from "lodash";
import { UrlLink, TokenData } from '../../constanst';
import Axios from "../../config";
import toastr from 'toastr'
import 'toastr/build/toastr.min.css'
import { Formik, Form, Field } from 'formik';

import roleSchema from "./RoleValidate";

const CheckBox = props => {
  return (

    <FormGroup check className="checkbox" key={props.name}>
      <Input className="form-check-input" key={props.name} onChange={props.handleCheckChieldElement} type="checkbox" checked={props.isChecked} value={props.name} />
      <Label check className="form-check-label" htmlFor={`checkbox${props.name}`}>{props.name}</Label>
    </FormGroup>


  )
}


class RoleEdit extends Component {

  constructor(props) {
    super(props);
    this.state = {
      role: {},
      permissions: [],
      grantedPermissions: [],

    }
  
  }
  isRoleInPermission(permissionName){
    let isRole=false
    
    _.map(this.state.role.grantedPermissions,item=>{
      if( _.toLower(item)===_.toLower(permissionName)){
        isRole=true;
      }
    })
    return isRole;
  }
  async componentDidMount() {
    try {
      var result = JSON.parse(localStorage.getItem(TokenData))

      if (result == null || !result.accessToken) {
        return;
      }
      const token = result.accessToken
      const response = await Axios.getInstance(token).get(`/api/services/app/role/Get?Id=${this.props.match.params.id}`)
      const responserole = await Axios.getInstance(token).get(`/api/services/app/Role/GetAllPermissions`)

      if (response.data.success && responserole.data.success) {
       
        this.setState({
          role: response.data.result,
          
        },()=>{
          var items = responserole.data.result.items.map((member) => {
            return {
              ...member,
              isChecked: this.isRoleInPermission(member.name)
            }
          });
          this.setState({
            permissions: items
          });
          
        });

        
      }
    } catch (error) {

      console.log(error);
    }
  }


  handleAllChecked = (event) => {
    let permissions = this.state.permissions
    permissions.forEach(fruite => fruite.isChecked = event.target.checked)
    this.setState({ permissions: permissions })
  }

  handleCheckChieldElement = (event) => {
    let permissions = this.state.permissions

    permissions.forEach(fruite => {
      if (_.toLower(fruite.name) === _.toLower(event.target.value))
        fruite.isChecked = event.target.checked
    })
    this.setState({ fruites: permissions }, () => {
      console.log(this.state.permissions);
    })
  }

  async onSave(values) {

    let permissions = [];
    _.map(this.state.permissions, item => {
      if (item.isChecked === true) {
        permissions.push(item.name)
      }
    });

    try {
      var result = JSON.parse(localStorage.getItem(TokenData))

      if (result == null || !result.accessToken) {
        return;
      }
      const token = result.accessToken

      const {displayName,name,id} = values

      const response = await Axios.getInstance(token).put(`/api/services/app/Role/Update`, {

        displayName: displayName,
        name: name,
        description:"",
        grantedPermissions:permissions,
        id:id
      })

      toastr.options = {
        positionClass: 'toast-top-right',
        hideDuration: 100,
        timeOut: 3000,
        progressBar: true,
      }
      // toastr.clear()//Xo?? c??c toastr tr?????c ????y
      toastr.success(`C???p nh???t vai tr?? th??nh c??ng`)

      if (response.data.success) {
        // this.setState({
        //   role: response.data.result
        // });
      }
    } catch (error) {

      toastr.options = {
        positionClass: 'toast-top-right',
        hideDuration: 100,
        timeOut: 3000,
        progressBar: true,
      }
      // toastr.clear()//Xo?? c??c toastr tr?????c ????y
      toastr.error(`???? c?? l???i trong qu?? tr??nh x??? l??`)
    }

  }

  onBack=()=> {
    
    this.props.history.go(-1);
    

  }

  render() {

    if (_.isEmpty(this.state.role)) return <div></div>;
    
    return (
      <div className="animated fadeIn">

        <Row>

          <Col lg={12}>
            <Formik
              initialValues={{
                id: this.state.role.id,
                name: this.state.role.name,
                displayName: this.state.role.displayName
              }}
              validationSchema={roleSchema}
              onSubmit={(values,{resetForm}) => {
                //Khi t???t c??c valid th?? n?? s??? ch???y v??o submit
                this.onSave(values);
                resetForm();
              }}
              onReset={values=>{
                  console.log(values);
              }}
            >
              {({ errors, touched,handleReset, isValidating,handleSubmit}) => (
                 <Card>

                 <CardHeader>
                   <strong><i className="icon-info pr-1"></i>Th??ng tin vai tr??</strong>
                 </CardHeader>
                 <CardBody>

                   <Col lg={6}>

                     <Form className="form-horizontal">

                       
                       <FormGroup row>
                         <Col md="3">
                           <Label htmlFor="text-input">T??n vai tr??</Label>
                         </Col>
                         <Col xs="12" md="9">
                          
                           <Field className={`form-control ${errors.name && touched.name && 'is-invalid' }`} name="name" type="text" placeholder="Nh???p t??n h??? t??i kho???n..." />
                           {errors.name && touched.name &&  <span className="invalid-feedback">{errors.name}</span>}

                         </Col>
                       </FormGroup>

                       <FormGroup row>
                         <Col md="3">
                           <Label htmlFor="text-input">T??n vai tr?? (vi???t t???c)</Label>
                         </Col>
                         <Col xs="12" md="9">
                           <Field className={`form-control ${errors.displayName && touched.displayName && 'is-invalid' }`} name="displayName" type="text"   placeholder="Nh???p t??n t??i kho???n..."/>
                           {errors.displayName && touched.displayName &&  <span className="invalid-feedback">{errors.displayName}</span>}
                         </Col>
                       </FormGroup>
                      
                       <FormGroup row>
                         <Col md="3"><Label>Vai tr??</Label></Col>
                         <Col md="9">
                           <FormGroup check className="checkbox">
                             <Input className="form-check-input" key="all" type="checkbox" onChange={this.handleAllChecked} value="checkedall" />
                             <Label check className="form-check-label" htmlFor={`checkboxall`}>T???t c???</Label>
                           </FormGroup>
                           {
                             _.map(this.state.permissions, item => {

                               return <CheckBox key={item.name} handleCheckChieldElement={this.handleCheckChieldElement}  {...item} />

                             })
                           }
                         </Col>
                       </FormGroup>
                     </Form>


                   </Col>

                 </CardBody>
                 <CardFooter>
                 
                   <Button onClick={handleSubmit}
                          type="submit" size="sm" color="success"><i className="fa fa-dot-circle-o"></i> L??u l???i</Button>
                   <Button type="reset" size="sm" color="primary" 
                       onClick={this.onBack}><i className="fa fa-ban"></i> Quay l???i</Button>
                   
                 </CardFooter>
               </Card>
              )}
            </Formik>
          </Col>
        </Row>
      </div>
    )
  }
}

export default withAuth(RoleEdit);
