import React, { useEffect } from "react";

import Container from "react-bootstrap/Container";
import Media from "react-bootstrap/Media";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Image from "react-bootstrap/Image";

import Me from "../assets/me-square.jpg";
import "./Home.css";

function Home(props) {
  useEffect(() => {
    document.title = "Peter Williams - Home";
  });

  return (
    <div className="mt-5 main-container">
      <Row>
        <Col>
          <Image
            className="image-me"
            width={200}
            src={Me}
            alt=""
            fluid
            roundedCircle
          />
          <h1 className="mt-3 font-weight-light">Peter Williams</h1>
          <h3 className="mt-3 font-weight-light">Portfolio</h3>
          <h5 className="mt-1 font-weight-light">Full stack developer</h5>
        </Col>
      </Row>
      <Row className="mt-3 pt-3 pb-3 off-color">
        <Col>
          <Image
            className="image-me"
            width={200}
            src={Me}
            alt=""
            fluid
            roundedCircle
          />
          <h1 className="mt-3 font-weight-light">Peter Williams</h1>
          <h3 className="mt-3 font-weight-light">Developer</h3>
          <h5 className="mt-1 font-weight-light">Full stack</h5>
        </Col>
      </Row>
    </div>
  );
}

export default Home;
