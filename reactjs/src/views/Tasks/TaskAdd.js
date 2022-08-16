
import React, { Component } from 'react';
import { Card, CardBody, Badge, CardHeader, Col, Row, CardFooter, Button, FormGroup, Label, Input, FormText } from 'reactstrap';
import withAuth from '../../hoc/withAuth';
import _ from "lodash";
import { UrlLink, TokenData } from '../../constanst';
import Axios from "../../config";
import toastr from 'toastr'
import 'toastr/build/toastr.min.css'
import { Formik, Form, Field } from 'formik';
import * as Yup from 'yup';
import DateTimePicker from 'react-datetime-picker';
import moment from 'moment';

import Select from 'react-select';

let projects = [
  { value: 1, label: 'MDCom' },
  { value: 2, label: 'PharmaCom' },
  { value: 3, label: 'NNA' },
  { value: 4, label: 'Haykhoe' },
  { value: 5, label: 'PharmaSales' },
  { value: 6, label: 'Medihub.vn' },
  { value: 7, label: 'Medihub.com.vn' },
  { value: 8, label: 'Các công việc khác' },
]

let employees = [
  { value: 1, label: 'Trần Văn Minh' },
  { value: 2, label: 'Vũ Xuân Bồng' },
  { value: 3, label: 'Trần Thị Nghĩa' },
  { value: 4, label: 'Nguyễn Thị Minh Anh' },
  { value: 5, label: 'Bảo' },
  { value: 6, label: 'Cường' },
  { value: 7, label: 'Tài' }
]


let difficulties = [
  { value: 1, label: 'Easy' },
  { value: 2, label: 'Medium' },
  { value: 3, label: 'Hard' },
  { value: 4, label: 'Expert' }
]


let urgents = [
  { value: 1, label: 'Low' },
  { value: 2, label: 'Medium' },
  { value: 3, label: 'High' },
  { value: 4, label: 'Critical' }
]

let ots = [
  { value: 'true', label: 'Yes' },
  { value: 'false', label: 'No' }
]

const UserSchema = Yup.object().shape({
  // userName:Yup.string()
  // .min(2, 'Tên đăng nhập quá ngắn!')
  // .max(30, 'Tên đăng nhập quá dài!')
  // .required('Tên đăng nhập không để trống'),
  name: Yup.string()
    .required('Tên họ không để trống'),
  // surname: Yup.string()
  //   .required('Tên lót không để trống'),
  // password:Yup.string()
  //   .required('Mật khẩu không để trống'),
  // emailAddress: Yup.string()
  //   .email('Không đúng định dạng email')
  //   .required('Email không để trống'),
});

class TaskAdd extends Component {
  constructor(props) {
    super(props);
    this.state = {
      roles: [],
      date: new Date(),
      assignment:'',
      projectName:'',
      difficulty:'',
      urgentLevel:'',
      overtime:'', 
      startTime: new Date(),
      endTime: new Date(),
      actualendTime: new Date(),
    }

    console.log(this.state);
    this.container = React.createRef();

  }

  calcDuration = () => {
    const { startTime, endTime } = this.state;
    let expectedDuration = moment.duration(moment(endTime).diff(moment(startTime))).asHours();
    return expectedDuration;
  };

  handleChangeAssignment = (assignment) => {
    this.setState({ assignment });
  }

  handleChangeprojectName = (projectName) => {
    this.setState({ projectName });
  }

  handleChangedifficulty = (difficulty) => {
    this.setState({ difficulty });
  }

  handleChangedurgentLevel = (urgentLevel) => {
    this.setState({ urgentLevel });
  }

  handleChangeduovertime = (overtime) => {
    this.setState({ overtime });
  }

  handleChangestartTime = (startTime) => {
    this.setState({ startTime });
  }

  handleChangeendTime = (endTime) => {
    this.setState({ endTime });
  }
  handleChangeactualendTime = (actualendTime) => {
    this.setState({ actualendTime });
  }
  async onSave(values) {

    

    try {
      var result = JSON.parse(localStorage.getItem(TokenData))

      if (result == null || !result.accessToken) {
        return;
      }
      const token = result.accessToken

      const { name } = values
      
      const response = await Axios.getInstance(token).post(`/api/services/app/Products/CreateProduct`, {

        name,
        assignment:this.state.assignment.label,
        projectName:this.state.projectName.label,
        difficulty:this.state.difficulty.label,
        urgentLevel:this.state.urgentLevel.label,
        checkin: moment(this.state.startTime),
        expectedCheckout: moment(this.state.endTime),
        checkout: moment(this.state.actualendTime),
        offtimeOverage:'0',
        overtime:true,
        percentilePerformance:0

      })

      toastr.options = {
        positionClass: 'toast-top-right',
        hideDuration: 100,
        timeOut: 3000,
        progressBar: true,
      }
      // toastr.clear()//Xoá các toastr trước đây
      toastr.success(`Thêm công việc thành công`)

      if (response.data.success) {
        // this.setState({
        //   user: response.data.result
        // });
      }
    } catch (error) {

      toastr.options = {
        positionClass: 'toast-top-right',
        hideDuration: 100,
        timeOut: 3000,
        progressBar: true,
      }
      // toastr.clear()//Xoá các toastr trước đây
      toastr.error(`Đã có lỗi trong quá trình xử lý`)
    }

  }


  onBack = () => {

    this.props.history.go(-1);
  }


  render() {

    console.log(this.state);
    if (this.state.user === null || this.state.user === {}) return;
    return (
      <div className="animated fadeIn">

        <Row>

          <Col lg={12}>
            <Formik
              initialValues={{
                id: 1,
                userName: "",
                name: "",
                surname: "",
                emailAddress: "",
                isActive: true,
                fullName: "",
                lastLoginTime: "",
                creationTime: "",
                password: ""
              }}
              validationSchema={UserSchema}
              onSubmit={values => {
                //Khi tất các valid thì nó sẽ chạy vào submit
                this.onSave(values);
              }}
              onReset={values => {

              }}
            >
              {({ errors, touched, handleReset, isValidating, handleSubmit }) => (
                <Card>


                  <CardHeader>
                    <strong><i className="icon-info pr-1"></i>Thông tin công việc</strong>
                  </CardHeader>
                  <CardBody>
                    <Form className="form-horizontal">
                      <Row>
                        <Col md={6}>

                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Chọn người nhận công việc</Label>
                            </Col>
                            <Col xs="12" md="9">
                              <Select options={employees} onChange={this.handleChangeAssignment}/>
                            </Col>
                          </FormGroup>

                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Chọn độ phức tạp</Label>
                            </Col>
                            <Col xs="12" md="9">

                             <Select options={difficulties} onChange={this.handleChangedifficulty} />
                            </Col>
                          </FormGroup>

                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Mô tả công việc</Label>
                            </Col>
                            <Col xs="12" md="9">

                              <Field className={`form-control ${errors.name && touched.name && 'is-invalid'}`} name="name"
                                type="text" id="name-input" placeholder="Mô tả công việc" autoComplete="email" />
                              {errors.name && touched.name && <span className="invalid-feedback">{errors.name}</span>}

                            </Col>
                          </FormGroup>


                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Thời gian làm</Label>
                            </Col>
                            <Col xs="12" md="9">

                              <DateTimePicker
                                onChange={(date)=>this.handleChangestartTime(date)}
                                value={this.state.startTime}
                              />

                            </Col>
                          </FormGroup>

                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Thời gian kết thúc</Label>
                            </Col>
                            <Col xs="12" md="9">

                              <DateTimePicker
                                name=''
                                onChange={(date)=>this.handleChangeendTime(date)}
                                value={this.state.endTime}
                              />

                            </Col>
                          </FormGroup>
                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Thời gian trừ dự kiến</Label>
                            </Col>
                            <Col xs="12" md="9">

                              <Field className={`form-control ${errors.checkout && touched.checkout && 'is-invalid'}`} name="checkout"
                                type="text" id="checkout-input" placeholder="Thời gian dự kiến" autoComplete="new-password"
                                  value={this.calcDuration()}/>
 
                            </Col>
                          </FormGroup>
                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Thời gian làm thực tế</Label>
                            </Col>
                            <Col xs="12" md="9">

                              <DateTimePicker
                                name='actualendTime'
                                onChange={(date)=>this.handleChangeactualendTime(date)}
                                value={this.state.actualendTime}
                              />

                            </Col>
                          </FormGroup>

                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Làm OT</Label>
                            </Col>
                            <Col xs="12" md="9">

                          
                              <Select options={ots} onChange={this.handleChangeduovertime}/>
                            </Col>
                          </FormGroup>

                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Hiệu suất công việc</Label>
                            </Col>
                            <Col xs="12" md="9">


                              <Field className={`form-control ${errors.percentilePerformance && touched.percentilePerformance && 'is-invalid'}`} name="percentilePerformance"
                                type="text" id="percentilePerformance-input" placeholder="Hiệu suất công việc..." autoComplete="new-password" />
                              {errors.percentilePerformance && touched.percentilePerformance && <span className="invalid-feedback">{errors.percentilePerformance}</span>}


                            </Col>
                          </FormGroup>

                        </Col>
                        <Col md={6}>
                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Chọn dự án</Label>
                            </Col>
                            <Col xs="12" md="9">
                              <Select options={projects} onChange={this.handleChangeprojectName}/>
                            </Col>
                          </FormGroup>
                          <FormGroup row>
                            <Col md="3">
                              <Label htmlFor="text-input">Chọn độ ưu tiên</Label>
                            </Col>
                            <Col xs="12" md="9">
                            
                              <Select options={urgents} onChange={this.handleChangedurgentLevel}/>
                            </Col>
                          </FormGroup>

                        </Col>
                      </Row>
                    </Form>
                  </CardBody>
                  <CardFooter>

                    <Button onClick={handleSubmit}
                      type="submit" size="sm" color="success"><i className="fa fa-dot-circle-o"></i> Lưu lại</Button>
                    <Button type="reset" size="sm" color="danger"
                      onClick={handleReset}><i className="fa fa-ban"></i> Làm lại</Button>
                    <Button type="submit" size="sm" color="primary"
                      onClick={this.onBack}><i className="fa fa-ban"></i> Quay lại</Button>
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

export default withAuth(TaskAdd);
