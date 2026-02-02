import React, { useState } from 'react';
import { Table, Button, Modal, Form } from 'react-bootstrap';

function User() {
    const [showModal, setShowModal] = useState(false);
    const [modalTitle, setModalTitle] = useState('Add New User');

    const handleOpenModal = (title) => {
        setModalTitle(title);
        setShowModal(true);
    };
    const handleCloseModal = () => setShowModal(false);

    const users = [
        { name: "Jacob", product: "Photoshop", sale: "28.76%", status: "Pending" },
        { name: "Messsy", product: "Flash", sale: "21.06%", status: "In progress" },
        { name: "John", product: "Premier", sale: "35.00%", status: "Fixed" },
        { name: "Peter", product: "After effects", sale: "82.00%", status: "Completed" },
        { name: "Dave", product: "53275535", sale: "98.05%", status: "In progress" },
    ];

    return (
        <div>
            <div className="page-header d-flex justify-content-between align-items-center">
                <h3 className="page-title"> User List </h3>
                <Button
                    className="btn btn-gradient-primary btn-rounded btn-fw"
                    onClick={() => handleOpenModal('Add New User')}
                >
                    Add New User
                </Button>
            </div>

            <div className="row">
                <div className="col-lg-12 grid-margin stretch-card">
                    <div className="card">
                        <div className="card-body">
                            <div className="table-responsive">
                                <Table className="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>User</th>
                                            <th>Product</th>
                                            <th>Sale</th>
                                            <th>Status</th>
                                            <th className="text-center">Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {users.map((user, idx) => (
                                            <tr key={idx}>
                                                <td>{user.name}</td>
                                                <td>{user.product}</td>
                                                <td className={user.sale.includes('-') ? 'text-danger' : 'text-success'}>
                                                    {user.sale} <i className={`mdi mdi-arrow-${user.sale.includes('-') ? 'down' : 'up'}`}></i>
                                                </td>
                                                <td>
                                                    <label className={`badge badge-${user.status === "Pending" ? "danger" : user.status === "In progress" ? "warning" : user.status === "Fixed" ? "info" : "success"}`}>
                                                        {user.status}
                                                    </label>
                                                </td>
                                                <td className="text-center">
                                                    <Button
                                                        size="sm"
                                                        variant="info"
                                                        className="me-2 btn-rounded btn-fw"
                                                        onClick={() => handleOpenModal('Edit User')}
                                                    >
                                                        Edit
                                                    </Button>
                                                    <Button
                                                        size="sm"
                                                        variant="danger"
                                                        className="btn-rounded btn-fw"
                                                        onClick={() => alert("Delete clicked")}
                                                    >
                                                        Delete
                                                    </Button>
                                                </td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </Table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {/* Popup Modal */}
            <Modal show={showModal} onHide={handleCloseModal} centered>
                <Modal.Header closeButton>
                    <Modal.Title>{modalTitle}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group className="mb-3">
                            <Form.Label>Username</Form.Label>
                            <Form.Control type="text" placeholder="Enter username" />
                        </Form.Group>
                        <Form.Group className="mb-3">
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" />
                        </Form.Group>
                      <Form.Group className="mb-3">
                                       <label htmlFor="exampleFormControlSelect1">select role</label>
                                       <select className="form-control form-control-lg" id="exampleFormControlSelect1">
                                         <option>1</option>
                                         <option>2</option>
                                         <option>3</option>
                                         <option>4</option>
                                         <option>5</option>
                                       </select>
                                     </Form.Group>
                          <Form.Group className="mb-3">
                                       <label htmlFor="exampleFormControlSelect1">select tenant</label>
                                       <select className="form-control form-control-lg" id="exampleFormControlSelect1">
                                         <option>1</option>
                                         <option>2</option>
                                         <option>3</option>
                                         <option>4</option>
                                         <option>5</option>
                                       </select>
                                     </Form.Group>
                          <Form.Group className="mb-3">
                                       <label htmlFor="exampleFormControlSelect1">Status</label>
                                       <select className="form-control form-control-lg" id="exampleFormControlSelect1">
                                         <option>Active</option>
                                         <option>InActive</option>
                                        
                                       </select>
                                     </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseModal}>Cancel</Button>
                    <Button variant="primary" onClick={handleCloseModal}>Submit</Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
}

export default User;
