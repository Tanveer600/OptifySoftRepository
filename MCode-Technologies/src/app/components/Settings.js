import React, { Component } from "react";
import { Tabs, Tab } from "react-bootstrap"; 

// App.scss is already globally imported in App.js
// So no need to import _tabs.scss here

export class Settings extends Component {
  state = { activeTab: "users" };

  render() {
    return (
      <div className="container-fluid">
        <div className="page-header">
          <h3 className="page-title">General Settings</h3>
        </div>

        <div className="row">
          <div className="col-12 grid-margin stretch-card">
            <div className="card">
              <div className="card-body">
            <Tabs
  activeKey={this.state.activeTab}
  onSelect={(k) => this.setState({ activeTab: k })}
  className="professional-tabs"
  id="settings-tabs"
>
  <Tab eventKey="users" title="Users">
    <div className="tab-content">
      <h5>Users</h5>
      <p>Yahan users ka data show hoga.</p>
    </div>
  </Tab>

  <Tab eventKey="products" title="Products">
    <div className="tab-content">
      <h5>Products</h5>
      <p>Yahan products ka data show hoga.</p>
    </div>
  </Tab>

  <Tab eventKey="orders" title="Orders">
    <div className="tab-content">
      <h5>Orders</h5>
      <p>Yahan orders ka data show hoga.</p>
    </div>
  </Tab>

  <Tab eventKey="reports" title="Reports">
    <div className="tab-content">
      <h5>Reports</h5>
      <p>Yahan reports ka data show hoga.</p>
    </div>
  </Tab>

  <Tab eventKey="settings" title="Settings">
    <div className="tab-content">
      <h5>Settings</h5>
      <p>Yahan settings ka data show hoga.</p>
    </div>
  </Tab>
</Tabs>

              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default Settings;
