import React from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

export default function Header() {
  return (
    <Navbar bg="dark" data-bs-theme="dark">
      <Container className="Align-start-flex">
        <Navbar.Brand href="/">Navbar</Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link href="/teste">Features</Nav.Link>
          <Nav.Link href="/filmes">Filmes</Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}
