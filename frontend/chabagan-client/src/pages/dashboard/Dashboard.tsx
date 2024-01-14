import { useEffect } from 'react';
import { IconBreadcrumbs } from '../../components/common/IconBreadcrumbs';
import dashboarBreadCrumb from '../../data/Breadcrumbs';
import { ProjectTitle } from '../../data/Config';

export default function Dashboard() {
    useEffect(() => {
        document.title = `Dashboard | ${ProjectTitle}`;
    }, []);
    return (
        <>
            <IconBreadcrumbs props={dashboarBreadCrumb.dashboarBreadCrumb} />
        </>
    )
}