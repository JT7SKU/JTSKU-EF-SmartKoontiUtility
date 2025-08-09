import { defineWorld } from "@latticexyz/world";

export default defineWorld({
  namespace: "test",
  tables: {    
    TurretAllowlist: {
      schema: {
        tribeId: "uint256"
      },
      key: [],
    }
  },
});