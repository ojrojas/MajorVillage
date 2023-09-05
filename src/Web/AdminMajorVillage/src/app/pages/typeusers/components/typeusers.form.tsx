import { Box, Button, FormControl, TextField, Typography } from "@mui/material";
import React from "react";
import { useForm } from "react-hook-form";
import { ITypeUser } from "../../../core/models/type/typeuser.model";
import useYupValidationResolver from "../../../helpers/resolver.forms";
import { schema } from "../schema/typeuser-form.schema";
import { useAppDispatch } from "../../../hooks";

interface Props {
    onClose: Function;
    typeUserExist?: ITypeUser;
    typeComponent: 'EDIT' | 'CREATE';
}

const TypeUsersFormComponent: React.FC<Props> = ({onClose, typeComponent, typeUserExist}) => {
    const dispatch = useAppDispatch();
    const { register, handleSubmit, formState: { errors } } = useForm<ITypeUser>({
        mode: 'all',
        defaultValues: typeUserExist,
        resolver: useYupValidationResolver(schema)
    })

    const onSubmit = handleSubmit(async () => {
        if(typeComponent === 'CREATE')
        {

        }else{
            
        }
    });

    return (
        <Box component={'form'}>
            <Typography>
                Create type users
            </Typography>
            <FormControl size="small" sx={{ m: 1, width: '30ch' }} variant="outlined">
                <TextField
                    size="small"
                    required
                    id="outlined-username"
                    data-testid="outlined-username"
                    error={errors.name ? true : false}
                    type={'text'}
                    {...register("name", { required: true })}
                    label={`Username`}
                    helperText={errors.name?.message ?? ''}
                />
            </FormControl>
            <FormControl sx={{ marginTop: 5 }}>
                <Button variant='text' onClick={onSubmit}>Login in</Button>
            </FormControl>
        </Box>
    );
}

export default TypeUsersFormComponent;