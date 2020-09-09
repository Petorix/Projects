const express = require("express");
const router = express.Router();

router.get("/api", (req, res) => {
  const data = "API content.";
  res.json(data);
});

router.get("/*", (req, res) => {
  const data = "Error 404 - Page not found.";
  res.json(data);
});

module.exports = router;