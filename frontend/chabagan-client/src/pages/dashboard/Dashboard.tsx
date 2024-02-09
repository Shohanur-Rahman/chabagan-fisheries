import { PieChart, pieArcLabelClasses } from '@mui/x-charts';
import { useEffect } from 'react';
import { IconBreadcrumbs } from '../../components/common/IconBreadcrumbs';
import dashboarBreadCrumb from '../../data/Breadcrumbs';
import { ProjectTitle } from '../../data/Config';
import { Box, Card, CardContent, Grid } from '@mui/material';
import StockList from '../../components/dashboard/StockList';
import IncomeExpenseLine from '../../components/dashboard/IncomeExpenseLine';
import FishChartFilterable from '../../components/dashboard/FishChartFilterable';

export default function Dashboard() {

    const data = [
        { value: 5, label: 'A' },
        { value: 10, label: 'B' },
        { value: 15, label: 'C' },
        { value: 20, label: 'D' },
    ];

    const size = {
        height: 300,
    };

    useEffect(() => {
        document.title = `Dashboard | ${ProjectTitle}`;
    }, []);
    return (
        <>
            <IconBreadcrumbs props={dashboarBreadCrumb.dashboarBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <StockList />
                    </Grid>

                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <IncomeExpenseLine />
                    </Grid>
                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <FishChartFilterable />
                    </Grid>

                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <Card sx={{ minWidth: 275, minHeight: 374 }} className="card w-100">
                            <CardContent>
                                <PieChart
                                    series={[
                                        {
                                            arcLabel: (item) => `${item.label} (${item.value})`,
                                            arcLabelMinAngle: 45,
                                            data,
                                        },
                                    ]}
                                    sx={{
                                        [`& .${pieArcLabelClasses.root}`]: {
                                            fill: 'white',
                                            fontWeight: 'bold',
                                        },
                                    }}
                                    {...size}
                                />
                            </CardContent>
                        </Card>
                    </Grid>
                </Grid>
            </Box>
        </>
    )
}