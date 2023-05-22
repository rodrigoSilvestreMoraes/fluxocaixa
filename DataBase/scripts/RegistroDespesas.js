db.createCollection("RegistroDespesas", {
  validator: {
    bsonType: "object",
    required: ["DadaCadastro", "DataPagamento", "Status", "CodigoDespesa", "EstaAgendado"],
    properties: {
      DadaCadastro: {
        bsonType: "Date"
      },
	  DataPagamento: {
        bsonType: "Date"
      },
      EstaAgendado: {
        bsonType: "bool"
      },
      Status: {
        bsonType: "int"
      },
      CodigoDespesa: {
        bsonType: "int"
      }
    }
  },
  validationLevel: "moderate",
  validationAction: "warn"
});

db.getCollection("RegistroDespesas").createIndex({ "DadaCadastro": 1 });
db.getCollection("RegistroDespesas").createIndex({ "DataPagamento": 1 });
db.getCollection("RegistroDespesas").createIndex({ "Status": 1 });
