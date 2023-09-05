import { Box, Button, Divider, FormControl, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField } from "@mui/material";
import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { getAllTypeUsers } from "../redux/typeusers.actions";

const ListTypeUsersComponent: React.FC = () => {
    const { getAllTypeUserResponse } = useAppSelector(state => state.typeUsers);
    const dispatch = useAppDispatch();

    useEffect(()=> {
        dispatch(getAllTypeUsers());
    }, [dispatch]);

    return (
        <React.Fragment>
            <h1>List Type Users</h1>
            <Divider />
            <br />
            <Box sx={{ width: '100%' }}>
                <Paper elevation={2}>
                    <Stack sx={{ display: 'flex', flexDirection: 'row', alignContent: 'center' }}>
                        <FormControl size="small" sx={{ m: 1, width: '30ch' }} variant="outlined">
                            <TextField
                                size="small"
                                id="outlined-search-typeusers"
                                data-testid="outlined-search-typeusers"
                                label="Search type"
                            />
                        </FormControl>
                        <FormControl size="small" sx={{ m: 1 }} variant="outlined">
                            <Button variant="outlined">Search</Button>
                        </FormControl>
                    </Stack>
                    <TableContainer>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>CreateAt</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    getAllTypeUserResponse && getAllTypeUserResponse.typeUsers.map((typeUser) => (
                                        <TableRow key={typeUser.id}>
                                            <TableCell>{typeUser.id}</TableCell>
                                            <TableCell>{typeUser.name}</TableCell>
                                        </TableRow>
                                    ))
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Paper>
            </Box>
        </React.Fragment>
    );
}

export default ListTypeUsersComponent;