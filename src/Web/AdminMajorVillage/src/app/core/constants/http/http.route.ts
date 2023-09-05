const apiIdentity = process.env.REACT_APP_API_IDENTITY;

export const HttpRoutes = {
    login: `${apiIdentity}connect/token`,
    typeUsers: {
        createTypeUser: `${apiIdentity}api/createtypeuser`,
        updateTypeUser: `${apiIdentity}api/getalltypeuser`,
        getAllTypeUsers: `${apiIdentity}api/getalltypeuser`,
        getTypeUserById: `${apiIdentity}api/gettypeuserbyid/`,
        deleteTypeUserById : `${apiIdentity}api/deletetypeuser/`
    }
}