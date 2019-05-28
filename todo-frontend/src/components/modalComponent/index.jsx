import React from "react";
import { Modal, Button, Form } from "react-bootstrap";
import "./style.css";

export default class ModalComponent extends React.Component {
  render() {
    return (
      <Modal
        {...this.props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            {this.props.task ? this.props.task.name : null}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body id="modalBody">
          <p>{this.props.task ? this.props.task.description : null}</p>
        </Modal.Body>
        <Modal.Footer>
          <Button onClick={this.props.onHide}>Close</Button>
        </Modal.Footer>
      </Modal>
    );
  }
}
