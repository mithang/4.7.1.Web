import React, { Component } from 'react';

import { Link,withRouter } from 'react-router-dom';
class NavCustom extends Component {
  
  constructor(props){
    super(props);
    this.state ={
      open:""
    }
    this.clickMenu = this.clickMenu.bind(this);
  }

  clickMenu(name,e){
   
      this.setState({
        open:name
      });
    
   
  }
  render() {
    
    return (
        <div className="sidebar">
        <nav className="sidebar-nav">
          <ul className="nav">
            <li className="nav-title">TRANG CHỦ</li>
            <li className="nav-item">
              <a className="nav-link">
                <i className="nav-icon cui-speedometer"></i> Nav item
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" >
                <i className="nav-icon cui-speedometer"></i> With badge
                <span className="badge badge-primary">NEW</span>
              </a>
            </li>

            <li className={`nav-item nav-dropdown ${this.state.open==='sys'? 'open':""}`} onClick={this.clickMenu.bind(this,"sys")}>
               <Link className="nav-link nav-dropdown-toggle">
                <i className="nav-icon cui-puzzle"></i> HỆ THỐNG
               </Link>
              <ul className="nav-dropdown-items">
                <li className="nav-item">
                <Link className={`nav-link ${this.props.history.location.pathname==="/users" && 'active'}`} to="/users"><i className="nav-icon cui-puzzle"></i> TÀI KHOẢN</Link>
                </li>
                <li className="nav-item">
                  <Link className={`nav-link ${this.props.history.location.pathname==="/roles" && 'active'}`} to="/roles"><i className="nav-icon cui-puzzle"></i> VAI TRÒ</Link>
                </li>
              </ul>
            </li>
           
          </ul>
        </nav>
        <button className="sidebar-minimizer brand-minimizer" type="button"></button>
        
      </div>
    
     
    );
  }
}
export default withRouter(NavCustom);