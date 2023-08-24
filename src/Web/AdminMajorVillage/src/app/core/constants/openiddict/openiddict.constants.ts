import { IOpeniddictAuth } from "../../models/openiddict/openiddict.model";

export const OpenIddictConstants: IOpeniddictAuth = {
    grant_type: process.env.REACT_APP_GRAND_TYPE!,
    scope: process.env.REACT_APP_SCOPE!,
    client_id: process.env.REACT_APP_CLIENT_ID!,
    client_secret: process.env.REACT_APP_SECRET_CLIENT!
}