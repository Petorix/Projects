// Imports
const express = require("express");
const mongoose = require("mongoose");
const morgan = require("morgan");
const path = require("path");
const routes = require("./routes/api");

const server = express();
const PORT = process.env.port || 8080;

// DB setup
mongoose.connect(process.env.MONGODB_URI || "mongodb://localhost/personal", {
  useNewUrlParser: true,
  useUnifiedTopology: true,
});
const db = mongoose.connection;
db.on("error", (e) => console.log(`DB error: ${e}`));
db.once("open", () => console.log("DB connected."));

server.use(express.json());
server.use(express.urlencoded({ encoded: false }));

server.use(morgan('tiny'));
server.use("/", routes);
server.listen(PORT, console.log(`Server is starting on port: ${PORT}`));