import { useEffect, useState } from "react";
import { ProjectTitle } from "../../data/Config";
import { Autocomplete, Card, CardContent, CardHeader, Grid, TextField } from "@mui/material";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import dayjs from "dayjs";
import { IAutocompleteModel } from "../../interfaces/model/IDropdownModel";

export default function PurchaseReport() {
    const [suppliers, setSuppliers] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);
    const [projects, setProjects] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);
    useEffect(() => {
        document.title = `Purchase Reports | ${ProjectTitle}`;
    }, []);

    return (
        <>
            <Grid item xs={12} sm={12} md={12} mt={2}>
                <Card sx={{ minWidth: 275 }} className="card w-100">
                    <CardHeader title="Purchase Reports" className="card-header" />
                    <CardContent className="table-content">
                        <Grid container spacing={2}>
                            <Grid item xs={6} sm={4} md={3}>
                                <LocalizationProvider dateAdapter={AdapterDayjs}>
                                    <DatePicker
                                        label="Start Date*"
                                        value={dayjs(new Date())}
                                        className="mt-0 datepicker-sm" />
                                </LocalizationProvider>
                            </Grid>

                            <Grid item xs={6} sm={4} md={3}>
                                <LocalizationProvider dateAdapter={AdapterDayjs}>
                                    <DatePicker
                                        label="End Date*"
                                        value={dayjs(new Date())}
                                        className="mt-0 datepicker-sm" />
                                </LocalizationProvider>
                            </Grid>

                            <Grid md={3} item xs={6}>
                                <Autocomplete
                                    disablePortal
                                    id="customer-combo"
                                    options={suppliers}
                                    renderInput={(params) => <TextField {...params} label="Supplier" size="small" />}
                                />
                            </Grid>

                            <Grid md={3} item xs={6}>
                                <Autocomplete
                                    disablePortal
                                    id="customer-combo"
                                    options={projects}
                                    renderInput={(params) => <TextField {...params} label="Project" size="small" />}
                                />
                            </Grid>

                        </Grid>
                    </CardContent>
                </Card>
            </Grid >
        </>
    )
}